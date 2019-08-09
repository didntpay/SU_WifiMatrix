#include <Adafruit_GFX.h>
#include <Adafruit_NeoMatrix.h>
#include <Adafruit_NeoPixel.h>

#define COLOR_INCREMENT 12
#define COLOR_DECREAMENT 10
#define WIDTH 32
#define HEIGHT 16

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
    matrix.drawLine(startx, starty, startx + 3, starty, matrix.Color(random(0, 255), random(0, 255), random(0, 255)));//define color later
    matrix.show();
    delay(10);
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

void colorTransitionLine()
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
}
