#include <Adafruit_GFX.h>
#include <Adafruit_NeoMatrix.h>
#include <Adafruit_NeoPixel.h>
#include <ESP8266WiFi.h>

#define LEDOUTPUT D5
#define wifiname  "jmw"//"SU-ECE-Lab"//change this when you are not at Seattle University3
#define wifipass  "2067799939"//"B9fmvrfe"

uint8_t firstled = NEO_MATRIX_TOP | NEO_MATRIX_LEFT | NEO_MATRIX_ZIGZAG;

Adafruit_NeoMatrix matrix = Adafruit_NeoMatrix(32, 10, LEDOUTPUT, firstled, NEO_GRB + NEO_KHZ800);
WiFiServer server(80);

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
  matrix.setBrightness(50);
  matrix.setTextColor(matrix.Color(255, 0, 0));//matrix.Color(r, g, b)  
}

int start_loc = matrix.width();
WiFiClient tmpClient = server.available();
void loop() {
  
  /*if(tmpClient)//this class overloaded the bool operator and returns the status of the connected field in the class
  {
    Serial.print("Connected to socket ip: ");
    Serial.println(tmpClient.remoteIP());
  }
  else if(!tmpClient)
  {
    //Serial.println("Waiting for connection...");
    tmpClient = server.available();
    delay(1000);
  }
  else{*/
  matrix.fillScreen(0);
  matrix.setCursor(start_loc, 3);
  matrix.print("Test");
  start_loc--;

  if(start_loc < -30)
  {
    start_loc = matrix.width();
    
  }
  matrix.show();
  delay(100);
  
}
