#include <Adafruit_GFX.h>
#include <Adafruit_NeoMatrix.h>
#include <Adafruit_NeoPixel.h>
#include <ESP8266WiFi.h>
#include <EEPROM.h>

#define LEDOUTPUT D5
#define wifiname  "SU-ECE-Lab" //"jmw" change this when you are not at Seattle University3
#define wifipass  "B9fmvrfe" //"2067799939"

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
Adafruit_NeoMatrix matrix = Adafruit_NeoMatrix(32, 10, LEDOUTPUT, firstled, NEO_GRB + NEO_KHZ800);
WiFiServer server(789);

enum Mode:byte {DEFAULTMODE = 0x40, AONE = 0x50, ATWO = 0x60, ATHREE = 0x70, SLEEP = 0x00};

struct Body
{
  String message;
  byte command;
  byte panel_mode;
};

Body socket_body;
Mode Led_Mode = DEFAULTMODE;

void setup() {
  Serial.begin(9600);
  WiFi.begin(wifiname, wifipass);
  socket_body = Body();
  byte tmp = EEPROM.read(0);
  if(tmp != NULL)
    socket_body.panel_mode = tmp;
  while(WiFi.status() != WL_CONNECTED)
  {
    Serial.println("Waiting to connect");
    delay(1000);
  }
  
  Serial.print("Connected to wifi, IP: ");
  Serial.println(WiFi.localIP());

  server.begin();
  // put your setup code here, to run once:
  pinMode(LEDOUTPUT, OUTPUT);
  matrix.begin();
  matrix.setTextWrap(false);
  matrix.setBrightness(10);
  matrix.setTextColor(matrix.Color(255, 0, 0));//matrix.Color(r, g, b)  
  }



WiFiClient tmpClient = server.available();
bool client_connect;


typedef struct header
{
  byte datatype;
  uint8_t len;
  byte messageoption;
  header(byte dt, uint8_t Len)
  {
    this->datatype = dt;
    this->len = Len; 
   }
   
   bool checkForInterrupt()
   {   
      if(!tmpClient)
        return false;
      
      if(tmpClient.available())
        return true;
      else
        return false; 
      
   }
}Software_Interrupt;





header socket_header(0x00, 0);

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
        for(int8_t i = startx; i > multiplier * endx; startx > endx ?i-- : i++)//scrolling horizontally right to left
        {
          
          matrix.fillScreen(0);
          matrix.setCursor(i, starty);
          matrix.print(message);
          matrix.show();
          unsigned long timeout = millis();
          while((millis() - timeout) < 100)
          {
            if(socket_header.checkForInterrupt())
            {
              matrix.fillScreen(0);
              return;
            }          
          }
          delay(100);    
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
          matrix.fillScreen(0);
          matrix.setCursor(startx, i);
          matrix.print(message);
          matrix.show();
          unsigned long timeout = millis();
          while((millis() - timeout) < 200)
          {
            if(socket_header.checkForInterrupt())
            {
              matrix.fillScreen(0);
              return;
            }          
          }    
        }
    }
}



void receiveData()//string for now, later, implement body to hold different values
{
  if(tmpClient.available()) 
  {  
      // first read the header: 2 byte, one of them is a char
      socket_header.datatype = tmpClient.read();
      socket_header.len = (char)tmpClient.read();
      //delete socket_body;
      //socket_body = NULL;
      //socket_body = Body();
      switch(socket_header.datatype)
      {
        case DATA_MESSAGE:
          socket_header.messageoption = tmpClient.read();
          //Serial.println(socket_header.datatype);
          for(int i = 0; i < socket_header.len; i++)
          {
            //Serial.println("Data in");
            socket_body.message += char(tmpClient.read());
          }
          break;
        case DATA_CMD:
          socket_body.panel_mode = tmpClient.read();
          break;
      }
  }
}





void loop() {
  //Serial.println(socket_body.panel_mode, HEX);
  if(socket_body.panel_mode != Led_Mode && socket_body.panel_mode != 0)
  {
  
    Led_Mode = (Mode)socket_body.panel_mode;
    Serial.println(Led_Mode, HEX);
    EEPROM.write(0, (byte)Led_Mode);
  }
  
  if(tmpClient)//this class overloaded the bool operator and returns the status of the connected field in the class
  {    
    
    if(!client_connect)
    {
      Serial.print("Connected to socket ip: ");
      Serial.println(tmpClient.remoteIP());
      client_connect = true;
    }
    receiveData();   
    
    
  }
  else if(!tmpClient)
  {    
    if(client_connect)
    {
      client_connect = false;
      Serial.println("Disconnected...");
    }
    tmpClient = server.available();
    delay(1000);
  }
  
  /*if(Led_Mode == DEFAULTMODE)
  {
      String defaultmessage = "YO";
      scrollingText(defaultmessage, WIDTH, 0, -WIDTH, 0);
  }
  else
  {
      String defaultmessage = "Different Mode";
      scrollingText(defaultmessage, WIDTH, 0, -WIDTH, 0); 
  }*/
  
  switch(socket_header.datatype)
  {
    case DATA_MESSAGE: 
      switch(socket_header.messageoption)
      {
        case SCROLL_RIGHT:
          scrollingText(socket_body.message, WIDTH, 0, -WIDTH, 0);
          break;
        case SCROLL_LEFT:
          scrollingText(socket_body.message, 0, 0, WIDTH * 2, 0);
          //Serial.println("Printing left to right");
          //scrollingText(message, WIDTH, 0, -WIDTH, 0);
          break;
        case SCROLL_TOP:
          scrollingText(socket_body.message, WIDTH / 2 - FONT_WIDTH, 0 - FONT_HEIGHT, WIDTH / 2 - FONT_WIDTH, HEIGHT * 2);
          break;
        case SCROLL_BOTTOM:
          scrollingText(socket_body.message, WIDTH / 2 - FONT_WIDTH, HEIGHT + FONT_HEIGHT, WIDTH / 2 - FONT_WIDTH, -HEIGHT);
          break;
      }
      break;
      
  }
  
}
