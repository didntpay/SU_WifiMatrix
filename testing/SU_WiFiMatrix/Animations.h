#include <Adafruit_GFX.h>
#include <Adafruit_NeoMatrix.h>
#include <Adafruit_NeoPixel.h>

#define COLOR_INCREMENT 12
#define COLOR_DECREAMENT 10

extern Adafruit_NeoMatrix matrix;

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
  for(int i = 0; i < 10; i++)
  {
    matrix.drawRect(startx + i, starty + i, width - i, height - i, matrix.Color(0 + i * COLOR_INCREMENT, 100 - i * COLOR_DECREAMENT, 0 + i * COLOR_INCREMENT));
    matrix.show();
    delay(1000);
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
  delay(2000);
  matrix.fillScreen(0);
}

void zigZagTraverse()
{
  for(int i = 0; i < 512; i+= 4)
  {    
    int starty = i / 32;
    int startx = i % 32;
    if(starty != 0 && starty % 2 != 0)
      startx += 32;
    matrix.drawLine(startx, starty, startx + 3, starty, matrix.Color());//define color later
    matrix.show();
    delay(10);
  }
}

void bpmSimulation(int8_t startx, int8_t starty, int8_t horizon_length; int8_t dia_length, int8_t step_length)
{
  matrix.fillScreen(0);
  matrix.setBrightness(50);
  for(int8_t i = 0; i < horizon_length; i += step_length)//first horizontal line for bpm
  {
    matrix.drawLine(i + startx, starty, i + startx + step_length, starty, matrix.Color(255, 0, 0));
    matrix.show();
    delay(10);
  }
  //upward diagonally line
  for(int i = startx + horizon_length; i < )
}

void oppositeRandomLine()
{
  
}


