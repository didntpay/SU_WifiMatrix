#include <Adafruit_GFX.h>
#include <Adafruit_NeoMatrix.h>
#include <Adafruit_NeoPixel.h>
#include <ESP8266WiFi.h>
#include <EEPROM.h>

#define LEDOUTPUT D5
#define wifiname  ""//"SU-ECE-Lab"//change this when you are not at Seattle University3
#define wifipass  "2067799939"//"B9fmvrfe"

#define COLOR_INCREAMENT 0.3
#define HEIGHT 16
#define WIDTH 32

uint8_t firstled = NEO_MATRIX_TOP | NEO_MATRIX_LEFT | NEO_MATRIX_ROWS;
Adafruit_NeoMatrix matrix = Adafruit_NeoMatrix(32, 16, LEDOUTPUT, firstled, NEO_GRB + NEO_KHZ800);
//WiFiServer server(80);



void setup() {
  Serial.begin(9600);
  /*WiFi.begin(wifiname, wifipass);
  //byte tmp = EEPROM.read(0);
  Serial.println(tmp);
  //EEPROM.write(0, 0x80);  
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
  //matrix.setTextWrap(false);
  matrix.setBrightness(100);
  //matrix.setRotation(1);
  //matrix.setTextColor(matrix.Color(255, 0, 0));//matrix.Color(r, g, b)  
  //matrix.drawRGBBitmap(b)*/

  EEPROM.begin(512);

  int value = (int)'a';
  for(int i = 0; i < 27; i++)
  {
   EEPROM.write(i, char(value)); 
   value++;
  }
  EEPROM.commit();

  for(int i = 0; i < 27; i++)
  {
    char value = EEPROM.read(i);
    Serial.println(value);
  }
}

void displayText(String message, int8_t startx, int8_t starty)
{
    matrix.fillScreen(0);//clear the screen
    matrix.setCursor(startx, starty);
    matrix.print(message);
}

uint16_t getColor(uint8_t value)
{
  if(value > 0)
    return matrix.Color(255, 0, 0);
  else
    return matrix.Color(0, 0, 0);
}

void displayHeart(int8_t startx, int8_t starty)
{
  matrix.fillScreen(0);
  for(int row = 0; row < 8; row++)
  {
    for(int col = 0; col < 8; col++)
    {
      //matrix.drawPixel(startx + col, starty + row, getColor(heart[row * 8 + col]));
    }
  }
  matrix.show();
}

void displayAllWhite()
{
  matrix.fillScreen(0);

  for(int i = 0; i < 16; i++)
  {
    for(int j = 0; j < 32; j++)
    {
       matrix.drawPixel(j, i, matrix.Color(255, 255, 255));
    }
    
    //matrix.fillScreen(0);
  }
  matrix.show();
  delay(200);
  matrix.fillScreen(0);
  matrix.show();
}

/*int start_loc = matrix.width();
WiFiClient tmpClient = server.available();
bool client_connect;*/

void loop() {
  
  
  
  
}
