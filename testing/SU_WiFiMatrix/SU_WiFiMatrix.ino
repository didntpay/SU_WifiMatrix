#include <Adafruit_GFX.h>
#include <Adafruit_NeoMatrix.h>
#include <Adafruit_NeoPixel.h>
#include <ESP8266WiFi.h>

#define LEDOUTPUT D5
#define wifiname  "jmw"//"SU-ECE-Lab"//change this when you are not at Seattle University3
#define wifipass  "2067799939"//"B9fmvrfe"
#define DATA_MESSAGE 0x80

uint8_t firstled = NEO_MATRIX_TOP | NEO_MATRIX_LEFT | NEO_MATRIX_ZIGZAG;
Adafruit_NeoMatrix matrix = Adafruit_NeoMatrix(32, 10, LEDOUTPUT, firstled, NEO_GRB + NEO_KHZ800);
WiFiServer server(789);


void setup() {
  Serial.begin(9600);
  WiFi.begin(wifiname, wifipass);

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

  header(byte dt, uint8_t Len)
  {
    this->datatype = dt;
    this->len = Len; 
   }
   
   bool checkForInterrupt()
   {
      if(tmpClient.available() || !tmpClient.connected())
        return true;
      else
        return false; 
   }
}Software_Interrupt;

struct body
{
  String messge;
  unsigned short* bmp PROGMEM;
};



header socket_header(0x00, 0);

void scrollingText(String& message, int8_t startx, int8_t starty, int8_t endx)
{
    matrix.fillScreen(0);//clear the screen
    matrix.setTextWrap(false);
    for(int8_t i = startx; i > endx; i--)//scrolling horizontally
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
    }
}

void receiveData(String& message)//string for now, later, implement body to hold different values
{
  if(tmpClient.available()) 
  {  
      // first read the header: 2 byte, one of them is a char
      socket_header.datatype = tmpClient.read();
      socket_header.len = (char)tmpClient.read();
      Serial.println(socket_header.len);
      switch(socket_header.datatype)
      {
        case DATA_MESSAGE:
          
          for(int i = 0; i < socket_header.len; i++)
          {
            Serial.println("Data in");
            message += char(tmpClient.read());
          }
          break;
      }
  }
}

void loop() {
  
  if(tmpClient)//this class overloaded the bool operator and returns the status of the connected field in the class
  {    
    String message = ""; 
    if(!client_connect)
    {
      Serial.print("Connected to socket ip: ");
      Serial.println(tmpClient.remoteIP());
      client_connect = true;
    }        

    receiveData(message);
    
    if(!message.equals(""))
    {
      scrollingText(message, matrix.width(), 0, -matrix.width());
    }
    
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
  //tmpClient.stop();
  
}
