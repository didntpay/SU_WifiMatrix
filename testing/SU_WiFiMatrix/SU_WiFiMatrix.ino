#include <Adafruit_GFX.h>
#include <Adafruit_NeoMatrix.h>
#include <Adafruit_NeoPixel.h>
#include <ESP8266WiFi.h>
#include <EEPROM.h>

#define LEDOUTPUT D5
#define wifiname   "jmw" //"SU-ECE-Lab" //change this when you are not at Seattle University3
#define wifipass    "2067799939"//"B9fmvrfe"

#define DATA_MESSAGE 0x80
#define DATA_CMD 0x90
#define DATA_BMP 0xA0

#define SCROLL_LEFT  0x10
#define SCROLL_RIGHT 0x01
#define SCROLL_TOP   0x11
#define SCROLL_BOTTOM 0x12

#define WIDTH 32
#define HEIGHT 10
#define FONT_HEIGHT 8
#define FONT_WIDTH 6

uint8_t firstled = NEO_MATRIX_TOP | NEO_MATRIX_LEFT | NEO_MATRIX_ZIGZAG;


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
const byte* animation_table = {snowflakes};
Adafruit_NeoMatrix matrix = Adafruit_NeoMatrix(32, 10, LEDOUTPUT, firstled, NEO_GRB + NEO_KHZ800);
WiFiServer server(789);

enum Mode:byte {DEFAULTMODE = 0x40, AONE = 0x50, ATWO = 0x60, ATHREE = 0x70, SLEEP = 0x00};
WiFiClient tmpClient = server.available();
bool client_connect;

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

Body socket_body;
Header socket_header(0x00, 0);

void setup() {
  Serial.begin(9600);
  EEPROM.begin(6);
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
  matrix.begin();
  matrix.setBrightness(10);
  matrix.setTextColor(matrix.Color(255, 0, 0));//matrix.Color(r, g, b) 


  }

bool displayText(int8_t x, int8_t y, String& message)
{
  matrix.fillScreen(0);
  matrix.fillScreen(0);
  matrix.setCursor(x, y);
  matrix.print(message);
  matrix.show();
  unsigned long timeout = millis();
  while((millis() - timeout) < 200)
  {
    socket_header.checkForConnection();
    if(socket_header.checkForInterrupt())
    {
      matrix.fillScreen(0);
      return true;
    }
                  
  }
  delay(0);
  return false;
}

void scrollingText(String& message, int8_t startx, int8_t starty, int8_t endx, int8_t endy)
{
    matrix.fillScreen(0);//clear the screen
    matrix.setTextWrap(false);
    if(startx != endx)
    {
        Serial.println("Printing horizontally");
        int8_t multiplier = 1;
        if(startx > endx)
          multiplier = 1;
        else
          multiplier = -1;
        for(int8_t i = startx; i > multiplier * endx; startx > endx ?i-- : i++)//scrolling horizontally 
        {         
          if(displayText(i, 0, message))
            return;
          //delay(100);
        }
        Serial.println(message);
    }
    else
    {
       Serial.println("Printing vertically");
       int8_t multiplier = 1;
        if(starty > endy)
          multiplier = 1;
        else
          multiplier = -1;
        for(int8_t i = starty; i > multiplier * endy; starty > endy ?i-- : i++)//scrolling horizontally right to left
        {
          if(displayText(0, i, message))
            return;  
        }
    }
}



void receiveData()//string for now, later, implement body to hold different values
{
  if(tmpClient.available()) 
  {  
      Serial.println("Now receiving data...");
      // first read the header: 2 byte, one of them is a char
      socket_header.datatype = tmpClient.read();
      socket_header.len = (char)tmpClient.read();
      if(socket_header.datatype == DATA_MESSAGE)
      {
          Serial.println("Receiving message");
          socket_header.messageoption = tmpClient.read();
          socket_body.message = "";
          for(int i = 0; i < socket_header.len; i++)
          {
            socket_body.message += char(tmpClient.read());
          }
      }
      else//DATA_CMD
      {
          Serial.println("New mode!");
          socket_body.panel_mode = tmpClient.read();
          Serial.println(socket_body.panel_mode);
      }
      socket_body.writeToEEPROM();
  }
}

void delayAndCheck(uint8_t interval)//ms
{
    unsigned long timeout = millis();
    while((millis() - timeout) < interval)
    {
      if(socket_header.checkForInterrupt())
      {
        matrix.fillScreen(0);
        receiveData();
      }              
    }
}

void playAnimation(uint8_t index, int8_t startx, int8_t starty)
{
  matrix.fillScreen(0);
  byte* animation = (byte*)animation_table[index];
  int8_t dimension = sizeof(animation) / sizeof(int);
  int8_t width = sqrt(dimension);
  Serial.println("Printing animation");
  for(int i = 0; i < dimension; i++)
  {
    matrix.drawPixel(startx + i % width, starty + i / width, matrix.Color(255, 255, 255));
  }
  matrix.show();
}

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
  
  if(socket_body.panel_mode == DEFAULTMODE)
  {
      /*for(int i = 0; i < 8; i++)
      {
        playAnimation(0, i, 1);
        delay(500);
      }*/
      String defaultmessage = "YO";
      scrollingText(defaultmessage, WIDTH, 0, -WIDTH, 0);
  }
  else if(socket_body.panel_mode == AONE)
  {
      String defaultmessage = "HE";
      scrollingText(defaultmessage, WIDTH, 0, -WIDTH, 0);
  }
  
  
  
}
