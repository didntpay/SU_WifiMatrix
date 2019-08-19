#include "Animations.h"

//Pin declaration
#define LEDOUTPUT D5
#define AUDIOREAD A0

#define wifiname   "jmw"//"SU-ECE-Lab" //change this when you are not at Seattle University
#define wifipass   "2067799939"//"B9fmvrfe" 

//flags for processing network transfer
#define DATA_MESSAGE 0x80
#define DATA_CMD 0x90
#define DATA_BMP 0xA0

//flags for displaying text
#define SCROLL_LEFT  0x10
#define SCROLL_RIGHT 0x01
#define SCROLL_TOP   0x11
#define SCROLL_BOTTOM 0x12

#define FONT_HEIGHT 8
#define FONT_WIDTH 6
#define TOTAL_ANIMATION 8

//Using the NeoMatrix Library to set up the control
//visit their github for more info
uint8_t firstled = NEO_MATRIX_TOP | NEO_MATRIX_LEFT | NEO_MATRIX_ROWS;
Adafruit_NeoMatrix matrix = Adafruit_NeoMatrix(32, 16, LEDOUTPUT, firstled, NEO_GRB + NEO_KHZ800);

WiFiServer server(789);
WiFiClient tmpClient = server.available();
bool client_connect;
uint16_t bgnoise;

Body socket_body;
Header socket_header(0x00, 0);

//An array of function pointers for the Default mode displays
//contains all the animation function so the chip can just loop
//through
void (*animations[11])() = {fadingRect, flashingCircle, zigZagTraverse, oppositeRandomLine, musicBar, 
                            colorTransitionLine, breathEffect,dropSnowFlakes, screenBomb, flashingWord, backAndForth};

//Default set up run by the chip
void setup() 
{
  Serial.begin(9600);
  EEPROM.begin(512);
  WiFi.begin(wifiname, wifipass);
  //it takes a few seconds to connect
  while(WiFi.status() != WL_CONNECTED)
  {
    Serial.println("Waiting to connect");
    delay(1000);
  }
  
  Serial.print("Connected to wifi, IP: ");
  Serial.println(WiFi.localIP());
  
  //Import the previous mode from the Flash if there is a preset mode
  if(socket_body.importFromEEPROM())
    Serial.println("Imported pre-set values from Flash");
  else
    Serial.println("Initalized socket body with default setting");

  //set up the server
  server.begin();
  pinMode(LEDOUTPUT, OUTPUT);
  pinMode(AUDIOREAD, INPUT);

  //call matrix.begin to set up the control
  matrix.begin();
  matrix.setBrightness(10);

}

/*********************************************************************
 * Display the text starting at a given x and y in a given color
 * @Param int8_t The x location for the text
 * @Param int8_t The y location for the text
 * @Param String& The given text to display
 * @Paran uint16_t The given color for the text
 *********************************************************************/
void displayText(int8_t x, int8_t y, String& message, uint16_t color)
{
  matrix.fillScreen(0);
  matrix.setTextColor(color);
  matrix.setCursor(x, y);
  matrix.print(message);
  matrix.show();
  delay(0);
}

/*********************************************************************
 * Calls the displayText fucntion iteratively and make it scroll through
 * the screen
 * @Param String& The given text
 * @Param int8_t The given x location
 * @Param int8_t The given y location
 * @Param int8_t The given ending x location
 * @Param int8_t The given ending y location
 * @Param uint16_t The given color
 *********************************************************************/
void scrollingText(String& message, int8_t startx, int8_t starty, int8_t endx, int8_t endy, uint16_t color)
{
    matrix.fillScreen(0);//clear the screen
    matrix.setTextWrap(false);
    if(startx != endx)
    {
        Serial.println("Printing horizontally");
        int8_t multiplier = 1;
        //determine if it is left to right or right to left
        if(startx > endx)
          multiplier = 1;
        else
          multiplier = -1;
        for(int8_t i = startx; i > multiplier * endx; startx > endx ?i-- : i++)//scrolling horizontally 
        {         
          displayText(i, 0, message, color);
          //delay(100);
          if(delayAndCheck(200))
            return;
        }
        Serial.println(message);
    }
    else
    {
       Serial.println("Printing vertically");
       int8_t multiplier = 1;
       //determine if it is up to bottom or bottom to top.
        if(starty > endy)
          multiplier = 1;
        else
          multiplier = -1;
        for(int8_t i = starty; i > multiplier * endy; starty > endy ?i-- : i++)//scrolling horizontally right to left
        {
          displayText(0, i, message, color);
          if(delayAndCheck(200))
            return;
        }
    }
}

/*********************************************************************
 * Reads from the audio sensor for detected value
 * 
 * @Param bool If true, it will only check for a few time. If false
 * the function stays on for 3o second and look for an average background
 * noise. Either way, this function is not blocked
 * 
 * @Return int16_t The detected value from sensor
 *********************************************************************/
int16_t readAudio(bool flag)
{
  long total = 0;
  long timer = millis();
  int count = 0;
  if(flag)
  {
    while(millis() - timer < 30000)
    {
      int temp = analogRead(AUDIOREAD);
      total += temp;
      count++;
      Serial.println(temp);
      delayAndCheck(1);
    }
    //take an average from 50 measurements
    Serial.println("Finish taking sample");
    Serial.print("Finalized at");
    Serial.println(total / count);
    return total / count;
  }
  else
  {
    for(int i = 0; i < 50; i++)
    {
      total += analogRead(AUDIOREAD);  
    }
    return total / 50;
  }
}

/*********************************************************************
 * Initalize a string array with ""
 * @Param String* The target string array
 * @Param int8_t The length of the array
 *********************************************************************/
void zeroArray(String* target, int8_t len)
{
  for(int i = 0; i < len; i++)
  {
    target[i] = "";
  }
}

/*********************************************************************
 * Receives incoming packages from the connected socket
 *********************************************************************/
void receiveData()
{
  //check for packages
  if(tmpClient.available())
  {
    //reads the header
    byte datatype = tmpClient.read();
    socket_header.len = tmpClient.read();
    bool message_change = false;
    //if the incoming packages contains message
    if(datatype == DATA_MESSAGE)
    {
        socket_header.messageoption = tmpClient.read();
        zeroArray(socket_body.message, 5);
        message_change = true;
        int mesgindex = 0;
        for(int i = 0; i < socket_header.len; i++)
        {
          char value = (char)tmpClient.read();
          
          if(value == 0xFF)
          {
            //Serial.println(socket_body.message[mesgindex]);
            mesgindex++;
          }
          else
          {
            socket_body.message[mesgindex] += value;
          }          
        }
    }
    else if(datatype = DATA_CMD) //if incoming package only contain command
    {
      Serial.println("New Mode");
      socket_body.panel_mode = tmpClient.read();
    }
    //saves data in flash
    socket_body.writeToEEPROM(message_change);
  }
}

/*********************************************************************
 * Play animation from the animation table defined in Animation.h
 * @Param int8_t The index of the animation in the table
 * @Param int8_t The starting x location of this animation
 * @param int8_t The starting y location of this animation
 *********************************************************************/
void playAnimation(uint8_t index, int8_t startx, int8_t starty)
{
  byte* animation = (byte*)animation_table[index];
  int8_t dimension = 121;
  
  int8_t width = sqrt(dimension);
  Serial.println("Printing animation");
  for(int i = 0; i < dimension; i++)
  {
    matrix.drawPixel(startx + i % width, starty + i / width, getColor(snowflakes[i]));
    if(i % width ==0)
      delay(10);
  }
  matrix.show();
}

uint16_t getColor(byte value)
{
  if(value > 0)
    return matrix.Color(255, 255, 255);

  return matrix.Color(0, 0, 0);
}

/*********************************************************************
 * Draws snowflakes from the animation table and create a dropping effect
 *********************************************************************/
void dropSnowFlakes()
{
  //Do it at three different section so they don't overlap
  int8_t ranx_left = random(0, 5);
  int8_t ranx_center = random(12, 18);
  int8_t ranx_right = random(24, 29);

  int8_t rany_left = random(-10, 5);
  int8_t rany_center = random(-10, 5);
  int8_t rany_right = random(-10, 5);
  
  for(int i = 0; i < HEIGHT; i++)
  {
    playAnimation(0, ranx_left, rany_left + i);
    playAnimation(0, ranx_center, rany_center + i);
    playAnimation(0, ranx_right, rany_right + i);

    delayAndCheck(200);

    matrix.fillScreen(0);
  }
}

int num = 0;
uint8_t mesg_index = 0;

void loop() {
  
  if(tmpClient.connected())
  {    
    
    if(!client_connect)
    {
      Serial.print("Connected to socket ip: ");
      Serial.println(tmpClient.remoteIP());
      client_connect = true;
    }
    receiveData();   

    //Keeping this here for reference to scroll text message from different direction, make sure to put
    //the message length into account.
    /*if(socket_header.datatype == DATA_MESSAGE)
    {
        
        switch(socket_header.messageoption)
        {
          case SCROLL_RIGHT:
            scrollingText(socket_body.message, WIDTH, 0, -WIDTH, 0);
            break;
          case SCROLL_LEFT:
            scrollingText(socket_body.message, 0, 0, WIDTH * 2, 0);
            break;
          case SCROLL_TOP:
            scrollingText(socket_body.message, WIDTH / 2 - FONT_WIDTH, 0 - FONT_HEIGHT, WIDTH / 2 - FONT_WIDTH, HEIGHT * 2);
            break;
          case SCROLL_BOTTOM:
            scrollingText(socket_body.message, WIDTH / 2 - FONT_WIDTH, HEIGHT + FONT_HEIGHT, WIDTH / 2 - FONT_WIDTH, -HEIGHT);
            break;
        }
    }*/
    
  }
  else if(!tmpClient.connected())
  {    
    if(client_connect)
    {
      client_connect = false;
      Serial.println("Disconnected...");
    }
    tmpClient = server.available();
  }


  long timer = millis();
  int16_t bgnoise;
  
  switch(socket_body.panel_mode)
  {
    //under default mode, play each animation in order. Each for 2 minutes.
    case DEFAULTMODE:
      while((millis() - timer < 30000))
      {
        (*animations[num])();
        if(socket_body.panel_mode != DEFAULTMODE)
          break;
        
        if(!socket_body.message[mesg_index].equals(" "))
          scrollingText(socket_body.message[mesg_index], WIDTH, 0, -WIDTH, 0, matrix.Color(random(0, 255), random(0, 255), random(0, 255)));
        
        delay(100);
        matrix.fillScreen(0);
      }
      num++;
      if(num == TOTAL_ANIMATION)
        num = 0;
      
      mesg_index++;
      if(mesg_index > 4)
      {
        mesg_index = 0;
      }
      bgnoise = readAudio(false);
      break;
    case FADINGRECT:
      fadingRect();
      break;
    case ZIGZAGTRAVERSE:
      zigZagTraverse();
      break;
    case FLASHINGCIR:
      flashingCircle();
      break;
    case MUSICBAR:
      timer = millis();
      while((millis() - timer < 60000))
      {
        musicBar();
        //matrix.fillScreen(0);
      }
      matrix.fillScreen(0);
      break;
    case OPPOSITERANDOMLINE:
      oppositeRandomLine();
      break;
    case COLORTRANSITION:
      colorTransitionLine();
      break;
    case BREATHEFFECT:
      breathEffect();
      break;
    case SCREENBOMB:
      screenBomb();
      break;
    case  BACKANDFORTH:
      backAndForth();
      break;
    case FLASHINGWORD:
      flashingWord();
      break;
    case CLAPLIGHT:
      clapTurnon();
      break;
  }
  
  
  
}
