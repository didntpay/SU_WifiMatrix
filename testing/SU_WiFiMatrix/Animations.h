#include <Adafruit_GFX.h>
#include <Adafruit_NeoMatrix.h>
#include <Adafruit_NeoPixel.h>
#include <ESP8266WiFi.h>
#include <EEPROM.h>

//Constants for animtaion
#define COLOR_INCREMENT 25
#define COLOR_DECREAMENT 30

//Width and height of the matrix
#define WIDTH 32
#define HEIGHT 16
#define DEFAULT_BRIGHTNESS 40
#define AUDIOSENSOR_TOLERANCE 2

//flags for different animation(mode)
enum Mode:byte {DEFAULTMODE = 0x40, FADINGRECT = 0x50, FLASHINGCIR = 0x60, ZIGZAGTRAVERSE = 0x70, BACKANDFORTH = 0x80, FLASHINGWORD = 0x90, 
                BREATHEFFECT = 0x10, OPPOSITERANDOMLINE = 0x20, SLEEP = 0x00, MUSICBAR = 0x30, COLORTRANSITION = 0xA0, SCREENBOMB = 0xB0,
                CLAPLIGHT = 0xC0};
                
extern WiFiClient tmpClient;
extern WiFiServer server;
extern Adafruit_NeoMatrix matrix;
extern uint16_t bgnoise;

byte heights[WIDTH]; // for the music bar animation
byte colors[WIDTH * 3];

//function declaration
bool delayAndCheck(uint16_t interval);
void receiveData();
void dropSnowFlakes();
void oppositeRandomLine();
void fewRandomLine(int8_t y, int8_t lines);
void displayText(int16_t x, int16_t y, String& message, uint16_t color);
void screenBomb();
void zeroArray(String* target, int8_t len);
int16_t readAudio(bool flag);

//bit map for the snowflake animation
const byte snowflakes[] =
{
  0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0,
  0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0,
  1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1,
  0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0,
  0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0,
  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
  0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0,
  0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0,
  1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1,
  0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0,
  0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0
};

//index table which points to the begining of each
//bit map array
const byte* animation_table = { snowflakes };

/*********************************************************************
* Network header for ESP8266
*********************************************************************/
typedef struct Header
{
  //data field
  byte datatype;
  uint8_t len;
  byte messageoption;

  /*********************************************************************
   * Header constructor
   * @Param byte flag to indicate what tyep of data should be sent
   * @param uint8_t length of the header
   *********************************************************************/
  Header(byte dt, uint8_t Len)
  {
    this->datatype = dt;
    this->len = Len; 
   }

   /*********************************************************************
   * Checks the connected socket for incoming packages
   * @Return Return true if there is incoming packages, false otherwise
   *********************************************************************/
   bool checkForInterrupt()
   {   
      if(!tmpClient.connected())
        return false;
      
      if(tmpClient.available())
        return true;
      else
        return false; 
      
   }

   /*********************************************************************
   * Checks the connected socket for incoming connection request
   *********************************************************************/
   void checkForConnection()
   {
      if(tmpClient.connected())
        return;
        
      tmpClient = server.available();
   }
}Software_Interrupt;

extern Header socket_header;

/*********************************************************************
 * A struct representing the body package sent over the network
 *********************************************************************/
struct Body
{
  String message[5];
  byte command;
  byte panel_mode;

  /*********************************************************************
   * Body default constructor
   *********************************************************************/
  Body()
  {
    for(int i = 0; i < 5; i++)
    {
      message[i] = " ";
    }
    this->command = 0x00;
    this->panel_mode = DEFAULTMODE;
  }

  /*********************************************************************
   * Body constructor
   * @Param byte Flag to indicate what tyep of command(mode) should be sent
   * @param byte Mode of the matrix(Animation)
   *********************************************************************/
  Body(byte cmd, byte ledmode)
  {
    //this->message = String(mes);
    this->command = cmd;
    this->panel_mode = ledmode;
  }

  /*********************************************************************
   * Saves the received data into flash for auto resets
   * @Param byte flag to indicate what variables should be save
   *********************************************************************/
  void writeToEEPROM(bool flag)
  {
    //flag true then saves message and mode
    if(flag)
    {
      byte buff[socket_header.len + 1];
      int8_t mesgindex = 0;
      uint16_t bufferedlength = 0;
      for(int i = 0; i < socket_header.len; i++)
      {
        if((i - bufferedlength) == this->message[mesgindex].length())
        {
          buff[i] = (char)0xFF;
          bufferedlength += this->message[mesgindex].length() + 1;
          mesgindex++;
          //+1 because this byte is used for spliter
        }
        else
        {
          buff[i] = (char)this->message[mesgindex].charAt(i - bufferedlength);
        }
      }

      buff[socket_header.len] = this->panel_mode;
    
      EEPROM.write(0, socket_header.len);
      for(int i = 0; i < sizeof(buff) / sizeof(byte); i++)
      {
        EEPROM.write(i + 1, buff[i]);
      }
      EEPROM.commit();
    }
    else
    {//flag false, then just save the matrix mode(animation)
      EEPROM.write(0, socket_header.len);
      EEPROM.write(socket_header.len + 1, this->panel_mode);
      EEPROM.commit();
    }
    
  }

  /*********************************************************************
   * Read from the flash on start up
   * @Return Returns true if there is data in the flash, false otherwise
   *********************************************************************/
  bool importFromEEPROM()
  {
    //the first byte is the length of the message send previously
    //which should never be zero unless it is a new chip
    if(EEPROM.read(0) == 0)
    {
      zeroArray(this->message, 5);
      this->command = 0;
      this->panel_mode = DEFAULTMODE;
      return false;
    }
    else
    {
        //manually saved at 0
        socket_header.len = EEPROM.read(0);
        uint8_t len = socket_header.len;
        uint8_t mesgindex = 0;
        
        zeroArray(this->message, 5);
        
        for(int i = 0; i < len; i++)
        {
          char value = EEPROM.read(i + 1);
          if(value == 0xFF)
          {
            mesgindex++;
          }
          else
          {
            this->message[mesgindex] += value;
          }
        }
        
        this->panel_mode = EEPROM.read(len + 1);
        return true;
    }
    
  }
};

/*********************************************************************
 * Display a rectangle at random location, random size. Zoom in from 
 * the center and then zoom out
 *********************************************************************/
void fadingRect()//draws a fading rectangle starting at a certain point and fade in
{
  
  int8_t rect_x = random(0, WIDTH);
  int8_t rect_y = random(0, HEIGHT);
  matrix.fillScreen(0);
  //zoom in
  for(int i = 0; i < 7; i++)
  {
    matrix.drawRect(rect_x + i, rect_y + i, WIDTH - rect_x - i * 2, HEIGHT - rect_y - i * 2, 
                    matrix.Color(0 + i * COLOR_INCREMENT, 100 - i * COLOR_DECREAMENT, 0 + i * COLOR_INCREMENT));
    matrix.show();
    if(delayAndCheck(500))
      return;
    matrix.fillScreen(0);
  }

  //zoom out
  for(int i = 6; i >= 0 ; i--)
  {
    matrix.drawRect(rect_x + i, rect_y + i, WIDTH - rect_x - i * 2, HEIGHT - rect_y - i * 2,  
                    matrix.Color(0 + i * COLOR_INCREMENT, 100 - i * COLOR_DECREAMENT, 0 + i * COLOR_INCREMENT));
    matrix.show();
    if(delayAndCheck(500))
      return;
    matrix.fillScreen(0);
  }
}

/*********************************************************************
 * Display multiple filled circle with random color
 *********************************************************************/
void flashingCircle()
{
  matrix.fillScreen(0);
  int8_t amount = random(0, 10);
  
  for(int i = 0; i < amount; i++)
  {
    int8_t tmpx = random(0, WIDTH);
    int8_t tmpy = random(0, HEIGHT);
    int8_t r = random(0, 128);
    int8_t g = random(0, 100);
    int8_t b = random(0, 128);    
    matrix.fillCircle(tmpx, tmpy, 3, matrix.Color(r, g, b));
    
  }
  matrix.show();
  
  if(delayAndCheck(500))
    return;
    
  matrix.fillScreen(0);
}

/*********************************************************************
 * Creates a line from start of the matrix and the end of the matrix
 * both moving toward each other. On their colision, display comet effect
 *********************************************************************/
void zigZagTraverse()
{
  for(int i = 0; i < 512; i+= 4)
  {    
    int starty = i / 32;
    int startx = i % 32;
    uint16_t color = matrix.Color(random(0, 255), random(0, 255), random(0, 255));

    //zig zag effect
    if(starty % 2 == 1)
      startx = 31 - startx ;
    //draws both line
    matrix.drawLine(startx, starty, startx + 3, starty, color);//define color later
    matrix.drawLine(WIDTH - 1 - startx, HEIGHT - 1 - starty, WIDTH - 1 - startx + 3, HEIGHT - 1 - starty, color);
    matrix.show();
    
    if(delayAndCheck(150 - (i * 0.4)))
      return;

    //wipes both lines
    matrix.drawLine(startx, starty, startx + 3, starty, matrix.Color(0, 0, 0));
    matrix.drawLine(WIDTH - 1 - startx, HEIGHT - 1 - starty, WIDTH - 1 - startx + 3, HEIGHT - 1 - starty, matrix.Color(0, 0, 0));
    
    if(starty == HEIGHT / 2 && startx == WIDTH / 2)
    {
      fewRandomLine(HEIGHT / 2, 3);
      break;
    }
  }
}

/*********************************************************************
 * Draws a few lines at different rows and move against each other
 * in random color
 *********************************************************************/
void backAndForth()
{
  matrix.fillScreen(0);
  int8_t index = random(0, 3);
  int8_t r = random(0, 205);
  int8_t g = random(0, 255);
  int8_t b = random(0, 100);
  uint16_t color = matrix.Color(r, g, b);
  for(int count = 0; count < 10; count++)
  {
    int j = 0;
    int i = 0;

    //if this part is not clear, look up th ? operator
    for(count % 2 == 0 ? j = 0 : j = 1; j < WIDTH; j+=3)
    {
      matrix.drawLine(j, i, j - 4, i, color);
      matrix.drawLine(WIDTH - 1 - j, i + 4, WIDTH - 1 - j + 4, i + 4, color);
      matrix.drawLine(j, i + 8, j - 4, i + 8, color);
      matrix.drawLine(WIDTH - 1 - j, i + 12, WIDTH - 1 - j + 4, i + 12, color);
      
      if(index == 0)
        color = matrix.Color(r, g + count * 18.8, b);
      else if(index == 1)
        color = matrix.Color(r, g, b + count * 18.8);
      else
        color = matrix.Color(r + count * 18.8, g, b);
        
      matrix.show();
      if(delayAndCheck(100))
        return;
        
      if(j != 0)
      {
        //delete the last line
        uint16_t black = matrix.Color(0, 0, 0);
        matrix.drawLine(j, i, j - 4, i, black);
        matrix.drawLine(WIDTH - 1 - j, i + 4, WIDTH - 1 - j + 4, i + 4, black);
        matrix.drawLine(j, i + 8, j - 4, i + 8, black);
        matrix.drawLine(WIDTH - 1 - j, i + 12, WIDTH - 1 - j + 4, i + 12, black);
      }          
    }    
  }
  matrix.fillScreen(0);
  
}

/*********************************************************************
 * Flashes words out and wipes the screen with random clor
 *********************************************************************/
void flashingWord()
{
  String message[6] = {"Ready?", "Seattle", "University", "Welcomes", "You", "All"}; 
  String words = "";
  for(int i = 0; i < 6; i++)
  {
    displayText(0, 0, message[i], matrix.Color(255, 255, 255));
    if(delayAndCheck(2000))
      return;
    matrix.fillScreen(0);
    matrix.show();
    
  }
  //wipes the screen
  screenBomb();
}

/*********************************************************************
 * Comet effect helper, display it in a certain row of the matrix
 * @Param int8_t The row number to start on
 * @Param int8_t The number of lines to display
 *********************************************************************/
void fewRandomLine(int8_t y, int8_t lines)
{
  for(int8_t tmp = 0; tmp < lines; tmp++)
  {
    for(int count = 0; count < 10; count++)
    {  
      int8_t ranx = random(0, 32);
      matrix.drawPixel(ranx, y + tmp, matrix.Color(205, 0, 0));
      matrix.drawPixel(WIDTH - ranx, y + tmp, matrix.Color(235, 235, 235));
      matrix.show();
      delayAndCheck(50);
    }
    matrix.fillScreen(0);
  }  
  matrix.fillScreen(0);
}

/*********************************************************************
 * Display a rectangle at random location, random size. Zoom in from 
 * the center and then zoom out
 *********************************************************************/
void oppositeRandomLine()
{
  //prints random color pixel starting on the top and bottom line and moving toward the cetner
 for(int i = 0; i < 80; i++)
 {
    int8_t ranx_top = random(0, WIDTH);
    int8_t ranx_bot = random(0, WIDTH);
    int8_t rany = random(0, HEIGHT);
    matrix.drawPixel(ranx_top, rany, matrix.Color(205, 0, 0));
    matrix.drawPixel(WIDTH - ranx_top, rany, matrix.Color(235, 235, 235));
    matrix.drawPixel(ranx_bot, HEIGHT - 1 - rany, matrix.Color(205, 0, 0));
    matrix.drawPixel(WIDTH - ranx_bot, HEIGHT - 1 - rany, matrix.Color(235, 235, 235));
    matrix.show();
    if(delayAndCheck(50))
      return;
 }

 matrix.fillScreen(0);
}

/*********************************************************************
 * Flashes the screen when a clap is detected
 *********************************************************************/
void clapTurnon()
{
  uint16_t color;

  color = matrix.Color(random(0, 255), random(0, 255), random(0, 255));
  int temp = readAudio(false);
  Serial.println(temp);
  if(temp > 12)
  {
    for(int y = 0; y < HEIGHT; y++)
    {
       for(int x = 0; x < WIDTH; x++)
       {
        matrix.drawPixel(x, y, color);
       }
      
    }
    matrix.show();
    if(delayAndCheck(200))
      return;
    matrix.fillScreen(0);
    matrix.show();
  }
}

/*********************************************************************
 * Draws a music bar graph and rises when a voice is detected
 * over the background noise
 *********************************************************************/
void musicBar()
{ 
  uint8_t index = 0;
  //initliaze the panel with some lines
  //only do so once
  if(matrix.getPixelColor((HEIGHT - 1) * WIDTH) == 0)
  {
    //HEIGHT - 1 * WIDTH) is the bottom left pixel
    matrix.fillScreen(0);
    
    for(int i = 0; i < WIDTH; i++)
    {
      int16_t value = readAudio(false);
      //initalize height base on noise level
      if(value > 12)
        value = 12;
      int8_t len = random(0, value);
      
      uint8_t r = random(0, 255);
      uint8_t g = random(0 , 255);
      uint8_t b = random(0, 255);
      
      matrix.drawLine(i, HEIGHT - 1, i, HEIGHT - 1 - len, matrix.Color(r, g, b));
      matrix.show();

      //keep tracks of the height and color for later
      heights[i] = HEIGHT - 1 - len;
      colors[index] = r;
      colors[index + 1] = g;
      colors[index + 2] = b;
      index += 3;
    }
  }

  index = 0;
  
  //base on the initlization, add or delete from it to make the groove.

  for(int i = 0; i < WIDTH; i++)
  {
    
    //range from deleting 5 pixels to adding 5 pixels
    int8_t len  = -1;
    int16_t currentnoiselevel = readAudio(false);
    if(currentnoiselevel > 9)
        len = 3;
    else if(currentnoiselevel > 13)
        len = 5;
    
    if(len > 0)
    {
      matrix.drawLine(i, heights[i], i, heights[i] - len, matrix.Color(colors[index], colors[index + 1], colors[index + 2]));
      heights[i] -= len;
    }
    else if(len < 0)
    {
      matrix.drawLine(i, heights[i], i, heights[i] + (-1 * len), matrix.Color(0, 0, 0));
      heights[i] += -1 * len;
      //if it decreased too much , set it the bottom
      if(heights[i] > 15)
        heights[i] = 15;
    }
        
    index += 3;
    if(delayAndCheck(10))
      return;
  }
  matrix.show();
}

/*********************************************************************
 * Draws a color changing line starting on row 1
 *********************************************************************/
void colorTransitionLine()
{
  int8_t delta_g = 5;
  int8_t delta_b = 10;
  int8_t delta_r = 2;
  for(int i = 0; i < HEIGHT; i++)
  {
    int8_t count = 0;
    //from green to blue
    for(int j = 0; j < WIDTH; j++)
    {
      matrix.drawPixel(j, i, matrix.Color(0, 128 - j * delta_g, 0 + delta_b * j));
      matrix.show();
      
      if(j % 31 == 0)
        matrix.fillScreen(0);
    }
    
    if(delayAndCheck(30))
      return;
      
    //from blue to purple
    delta_b = 8;
    for(int j = WIDTH - 1; j >= 0; j--)
    {
      matrix.drawPixel(j, i, matrix.Color(50 + delta_r * j, 0, 255 - delta_b * j));
      matrix.show();
    }
  } 
}

/*********************************************************************
 * Fill the screen with random color and creates a moving effect
 *********************************************************************/
void screenBomb()
{
  int8_t y = 1;
  uint16_t colors[3][3] = {matrix.Color(255, 141, 0), matrix.Color(255, 222, 0), matrix.Color(188, 255, 0),
                           matrix.Color(0, 192, 255), matrix.Color(0, 98, 255), matrix.Color(124, 0, 255),
                           matrix.Color(201, 0, 255), matrix.Color(255, 0, 162), matrix.Color(255, 0, 107)};
  int8_t index = random(0, 3);
  
  for(int8_t times = 0; times < 3; times++)
  {
    for(int8_t cols = 0; cols < HEIGHT; cols ++)
    {
      for(int8_t x = 0; x < WIDTH; x++)
      {
        matrix.drawPixel(x, cols, colors[index][times]);
        
        //if the current row is filled 1/3, start on the next row simultaneously
        if(x > WIDTH / 3 && (cols + 1 < HEIGHT))
          matrix.drawPixel(x, cols + 1, colors[index][times]);
          
      }  
      
      matrix.show();    
      delayAndCheck(10);
    }
  }
  
  delayAndCheck(100);
  matrix.fillScreen(0);
}

/*********************************************************************
 * Creates the breath effect for the screen
 *********************************************************************/
void breathEffect()
{
  matrix.fillScreen(0);
  matrix.setBrightness(0);
  uint16_t colors[3] = {matrix.Color(255, 0, 0), matrix.Color(0, 255, 0), matrix.Color(0, 0, 255)};
  int8_t index = random(0, 3);
  uint16_t color = colors[index];
  for(int count = 1; count <= 10; count++)
  {
    int i;
    for((count % 2 == 0) ? i = 0 : i = 1; i < HEIGHT; i += 2)
    {
      for(int j = 0; j < WIDTH; j++)
      {
        matrix.drawPixel(j, i, color);
        if(index == 0)
          color = matrix.Color(255, 0 + count * 23.8, 0);
        else if(index == 1)
          color = matrix.Color(0, 255, 0 + count * 23.8);
        else
          color = matrix.Color(0 + count * 23.8, 0, 255);
          
      }
    }

    for(int times = 1; times <= 10; times++)
    {
      matrix.setBrightness(times * (DEFAULT_BRIGHTNESS / 10));
      matrix.show();
      if(delayAndCheck(100))
        return;
    }
    
    for(int times = 0; times < 10; times++)
    {
      matrix.setBrightness(DEFAULT_BRIGHTNESS - times * (DEFAULT_BRIGHTNESS / 10));
      matrix.show();
      if(delayAndCheck(100))
        return;
    }
    matrix.fillScreen(0);
  }
}

/*********************************************************************
 * Check for incoming packages and incoming connection request
 * @Param uint16_t Time interval to keep runing this check
 * @Return Returns true if there is packages or connection
 * false otherwise
 *********************************************************************/
bool delayAndCheck(uint16_t interval)//ms
{
    unsigned long timeout = millis();
    while((millis() - timeout) < interval)
    {
      socket_header.checkForConnection();
      if(socket_header.checkForInterrupt())
      {
        matrix.fillScreen(0);
        receiveData();
        return true;
      }                
    }
    return false;
}
