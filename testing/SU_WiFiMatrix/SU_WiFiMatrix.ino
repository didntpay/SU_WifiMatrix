#include "Animations.h"

#define LEDOUTPUT D5
#define AUDIOREAD A0
#define wifiname   "Oasis Guest"//"iPhone (49)"//"SU-ECE-Lab" //change this when you are not at Seattle University
#define wifipass   "Oasis519"//"B9fmvrfe" //

#define DATA_MESSAGE 0x80
#define DATA_CMD 0x90
#define DATA_BMP 0xA0

#define SCROLL_LEFT  0x10
#define SCROLL_RIGHT 0x01
#define SCROLL_TOP   0x11
#define SCROLL_BOTTOM 0x12

#define FONT_HEIGHT 8
#define FONT_WIDTH 6

#define AUDIOSENSOR_TOLERANCE 50

#define TOTAL_ANIMATION 8
uint8_t firstled = NEO_MATRIX_TOP | NEO_MATRIX_LEFT | NEO_MATRIX_ROWS;

Adafruit_NeoMatrix matrix = Adafruit_NeoMatrix(32, 16, LEDOUTPUT, firstled, NEO_GRB + NEO_KHZ800);
WiFiServer server(789);
WiFiClient tmpClient = server.available();
bool client_connect;



Body socket_body;
Header socket_header(0x00, 0);
void (*animations[11])() = {fadingRect, flashingCircle, zigZagTraverse, oppositeRandomLine, musicBar, 
                            colorTransitionLine, breathEffect,dropSnowFlakes, screenBomb, flashingWord, backAndForth};

void setup() 
{
  Serial.begin(9600);
  EEPROM.begin(512);
  WiFi.begin(wifiname, wifipass);
  
  while(WiFi.status() != WL_CONNECTED)
  {
    Serial.println("Waiting to connect");
    delay(1000);
  }
  
  Serial.print("Connected to wifi, IP: ");
  Serial.println(WiFi.localIP());
  if(socket_body.importFromEEPROM())
    Serial.println("Imported pre-set values from Flash");
  else
    Serial.println("Initalized socket body with default setting");

  server.begin();
  // put your setup code here, to run once:
  pinMode(LEDOUTPUT, OUTPUT);
  pinMode(AUDIOREAD, INPUT);
  matrix.begin();
  matrix.setBrightness(10);

}

bool displayText(int8_t x, int8_t y, String& message, uint16_t color)
{
  matrix.fillScreen(0);
  matrix.setTextColor(color);
  matrix.setCursor(x, y);
  matrix.print(message);
  matrix.show();
  /*unsigned long timeout = millis();
  while((millis() - timeout) < 200)
  {
    socket_header.checkForConnection();
    if(socket_header.checkForInterrupt())
    {
      matrix.fillScreen(0);
      return true;
    }
                  
  }*/
  delay(0);
  return false;
}

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
          if(displayText(i, 0, message, color))
            return;
          //delay(100);
          delayAndCheck(200);
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
          if(displayText(0, i, message, color))
            return;  
          delayAndCheck(200);
        }
    }
}

int16_t readAudio()
{
  int total = 0;
  for(int i = 0; i < 10; i++)
  {
    total += digitalRead(i);
  }
  //take an average from 10 measurements
  return total / 10;
}

void zeroArray(String* target, int8_t len)
{
  for(int i = 0; i < len; i++)
  {
    target[i] = "";
  }
}

void receiveData()//string for now, later, implement body to hold different values
{
  if(tmpClient.available())
  {
    byte datatype = tmpClient.read();
    socket_header.len = tmpClient.read();
    if(datatype == DATA_MESSAGE)
    {
        socket_header.messageoption = tmpClient.read();
        zeroArray(socket_body.message, 5);
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
    else if(datatype = DATA_CMD)
    {
      Serial.println("New Mode");
      socket_body.panel_mode = tmpClient.read();
      Serial.println(socket_body.panel_mode);
    }
    //saves data in flash
    socket_body.writeToEEPROM();
    Serial.println(socket_body.message[4]);
  }
}



void playAnimation(uint8_t index, int8_t startx, int8_t starty)
{
  //matrix.fillScreen(0);
  byte* animation = (byte*)animation_table[index];
  int8_t dimension = 121;
  //Serial.println(*animation, HEX);
  //Serial.println(*(&snowflakes[0]), HEX);
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

//dropping snowflakes at 3 divided section
void dropSnowFlakes()
{
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
  //Serial.println(socket_body.panel_mode, HEX);
  
  if(tmpClient.connected())//this class overloaded the bool operator and returns the status of the connected field in the class
  {    
    
    if(!client_connect)
    {
      Serial.print("Connected to socket ip: ");
      Serial.println(tmpClient.remoteIP());
      client_connect = true;
    }
    receiveData();   
    
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
  else if(!tmpClient)
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
      //Serial.println(socket_body.message[4]);
      bgnoise = readAudio();
      while((millis() - timer < 30000) && readAudio() > bgnoise - AUDIOSENSOR_TOLERANCE)
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
      musicBar();
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
  }
  
  
  
}
