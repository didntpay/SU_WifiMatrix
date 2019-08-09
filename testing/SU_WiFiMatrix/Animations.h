#include <Adafruit_GFX.h>
#include <Adafruit_NeoMatrix.h>
#include <Adafruit_NeoPixel.h>
#include <ESP8266WiFi.h>
#include <EEPROM.h>

#define COLOR_INCREMENT 30
#define COLOR_DECREAMENT 30
#define WIDTH 32
#define HEIGHT 16



enum Mode:byte {DEFAULTMODE = 0x40, AONE = 0x50, ATWO = 0x60, ATHREE = 0x70, SLEEP = 0x00};
extern WiFiClient tmpClient;
extern WiFiServer server;


//function declaration
void delayAndCheck(uint8_t interval);
void receiveData();

struct Body
{
  String message;
  byte command;
  byte panel_mode;

  Body()
  {
    this->message = "";
    this->command = 0x00;
    this->panel_mode = DEFAULTMODE;
  }
  
  Body(const char* mes, byte cmd, byte ledmode)
  {
    this->message = String(mes);
    this->command = cmd;
    this->panel_mode = ledmode;
  }
  
  void writeToEEPROM()
  {
    byte buff[6];
    for(int i = 0; i < 4; i++)
    {
      buff[i] = (char)message.charAt(i);
    }
    buff[4] = command;
    buff[5] = panel_mode;

    for(int i = 0 ; i < 6; i++)
    {
      EEPROM.write(i, buff[i]);
    }
    EEPROM.commit();
    Serial.println("Saved data in Flash");
  }

  bool importFromEEPROM()
  {
    if(EEPROM.read(5) == 0)
    {
      this->message = "";
      this->command = 0x00;
      this->panel_mode = DEFAULTMODE;
      return false;
    }
    else
    {
      for(int i = 0; i < 4; i++)
      {
        this->message += EEPROM.read(i);    
      }
      this->command = EEPROM.read(4);
      this->panel_mode = EEPROM.read(5);
      return true;
    }
  }
};

typedef struct Header
{
  byte datatype;
  uint8_t len;
  byte messageoption;
  Header(byte dt, uint8_t Len)
  {
    this->datatype = dt;
    this->len = Len; 
   }
   
   bool checkForInterrupt()
   {   
      if(!tmpClient.connected())
        return false;
      
      if(tmpClient.available())
        return true;
      else
        return false; 
      
   }
   
   void checkForConnection()
   {
      if(tmpClient.connected())
        return;
        
      tmpClient = server.available();
   }
}Software_Interrupt;

extern Adafruit_NeoMatrix matrix;
extern Header socket_header;

const int heart[] = {       // Heart bitmap
  0, 1, 1, 0, 1, 1, 0, 0,
  1, 1, 1, 1, 1, 1, 1, 0,
  1, 1, 1, 1, 1, 1, 1, 0,
  1, 1, 1, 1, 1, 1, 1, 0,
  0, 1, 1, 1, 1, 1, 0, 0,
  0, 0, 1, 1, 1, 0, 0, 0,
  0, 0, 0, 1, 0, 0, 0, 0,
  0, 0, 0, 0, 0, 0, 0, 0
};

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

const byte* animation_table = { snowflakes };

void fadingRect(int8_t startx, int8_t starty, int8_t width, int8_t height)//draws a fading rectangle starting at a certain point and fade in
{
  matrix.fillScreen(0);
  for(int i = 0; i < 7; i++)
  {
    matrix.drawRect(startx + i, starty + i, width - i * 2, height - i * 2, matrix.Color(0 + i * COLOR_INCREMENT, 100 - i * COLOR_DECREAMENT, 0 + i * COLOR_INCREMENT));
    matrix.show();
    delayAndCheck(1000);
    matrix.fillScreen(0);
  }

  for(int i = 6; i >= 0 ; i--)
  {
    matrix.drawRect(startx + i, starty + i, width - i * 2, height - i * 2, matrix.Color(0 + i * COLOR_INCREMENT, 100 - i * COLOR_DECREAMENT, 0 + i * COLOR_INCREMENT));
    matrix.show();
    delayAndCheck(1000);
    matrix.fillScreen(0);
  }
}

void flashingCircle(int8_t maxx, int8_t maxy)
{
  matrix.fillScreen(0);
  int8_t amount = random(0, 10);
  for(int i = 0; i < amount; i++)
  {
    int8_t tmpx = random(0, maxx);
    int8_t tmpy = random(0, maxy);
    int8_t r = random(0, 128);
    int8_t g = random(0, 100);
    int8_t b = random(0, 128);    
    matrix.fillCircle(tmpx, tmpy, 3, matrix.Color(r, g, b));
    
  }
  matrix.show();
  delayAndCheck(2000);
  matrix.fillScreen(0);
}

void zigZagTraverse()
{
  for(int i = 0; i < 512; i+= 4)
  {    
    int starty = i / 32;
    int startx = i % 32;
    if(starty % 2 == 1)
      startx = 31 - startx ;
    matrix.drawLine(startx, starty, startx + 3, starty, matrix.Color(random(0, 255), random(0, 255), random(0, 255)));//define color later
    matrix.show();
    delayAndCheck(10);
    matrix.drawLine(startx, starty, startx + 3, starty, matrix.Color(0, 0, 0));
  }
}

void bpmSimulation(int8_t startx, int8_t starty, int8_t horizon_length, int8_t dia_length, int8_t step_length)
{
  matrix.fillScreen(0);
  matrix.setBrightness(50);
  for(int8_t i = 0; i < horizon_length; i += step_length)//first horizontal line for bpm
  {
    matrix.drawLine(i + startx, starty, i + startx + step_length, starty, matrix.Color(255, 0, 0));
    matrix.show();
    delay(10);
  }

  startx += horizon_length;
  //upward diagonally line
  for(int i = 0; i < dia_length; i += step_length)
  {
    int8_t tmp_x = startx + i;
    int8_t tmp_y = starty + i;
    matrix.drawLine(tmp_x, tmp_y, tmp_x + step_length, tmp_y + step_length, matrix.Color(255, 0, 0));
    matrix.show();
    delay(10);
  }

  startx += dia_length;
  starty += dia_length;

  //downward diagonal line
  for(int i = 0; i < dia_length; i += step_length)
  {
    int8_t tmp_x = startx - i;
    int8_t tmp_y = starty - i;
    matrix.drawLine(tmp_x, tmp_y, tmp_x - step_length, tmp_y - step_length, matrix.Color(255, 0, 0));
    matrix.show();
    delay(10);
  }

  startx += dia_length;
  starty -= dia_length;

  //finishing horizontal line
  for(int i = 0; i < horizon_length; i++)
  {
    matrix.drawLine(i + startx, starty, i + startx + step_length, starty, matrix.Color(255, 0, 0));
    matrix.show();
    delay(10);
  }
  
}

void oppositeRandomLine()
{//prints random color pixel starting on the top and bottom line and moving toward the cetner
 for(int y = 0; y < 16; y++)
 {
  for(int count = 0; count < 10; count++)
  {
    int8_t ranx_top = random(0, 32);
    int8_t ranx_bot = random(0, 32);
    int8_t r = random(0, 255);
    int8_t g = random(0, 255);
    int8_t b = random(0, 255);
  
    matrix.drawPixel(ranx_top, y, matrix.Color(r, g, b));
    matrix.drawPixel(ranx_bot, y + HEIGHT - 1, matrix.Color(r, g, b));
    matrix.show();
  }
  delay(100);
  matrix.fillScreen(0);
  
 } 
}



void musicBar()
{
  for(int i = 0; i < WIDTH; i++)
  {
    int8_t len = random(0, 14);
    matrix.drawLine(i, HEIGHT - 1, i, len, matrix.Color(random(0, 255), random(0, 255), random(0, 255)));
    matrix.show();
    delay(0);    
  }
}

/*void colorTransitionLine()
{
  int8_t delta_g = 4;
  int8_t delta_b = 8;
  int8_t delta_r = 2;
  for(int i = 0; i < HEIGHT; i++)
  {
    int8_t count = 0;
    //from green to blue
    for(int j = 0; j < WIDTH; j++)
    {
      matrix.drawPixel(j, i, matrix.Color(0, 128 - j * delta_g, 0 + delta_b * j));
      matrix.show();
      if(j > WIDTH / 2)
      {
        matrix.drawPixel(count, i, matrix.Color(0, 0, 0));
        matrix.show();
        count++;
      }
    }
    delay(30);
    //from blue to purple
    delta_b = 4;
    for(int j = WIDTH - 1; j >= 0; j--)
    {
      matrix.drawPixel(j, i, matrix.Color(0 + delta_r * j, 0, 255 - delta_b * j));
      matrix.show();
      if(j < WIDTH / 2)
      {
        matrix.drawPixel(count, i, matrix.Color(0, 0, 0));
        matrix.show();
        count--;
      }
    } 
}*/

void delayAndCheck(uint8_t interval)//ms
{
    unsigned long timeout = millis();
    while((millis() - timeout) < interval)
    {
      socket_header.checkForConnection();
      if(socket_header.checkForInterrupt())
      {
        matrix.fillScreen(0);
        receiveData();
      }              
    }
}
