#include <LedControl.h>
#include <Wire.h>
#include "RTClib.h"
//#include <binary.h>



// http://www.ithepro.com/2015/11/kyx-5461as-4-digit-7-segment-led.html
// http://playground.arduino.cc/Main/LedControl
//http://www.instructables.com/id/Real-time-clock-using-DS3231-EASY/?ALLSTEPS
//https://learn.adafruit.com/adafruit-ds3231-precision-rtc-breakout/wiring-and-test


int latchPin = 10;
int clockPin = 11;
int dataPin = 12;

LedControl lc1=LedControl(dataPin,clockPin,latchPin,1);
RTC_DS3231 rtc;

void setup()
{
 pinMode(latchPin, OUTPUT);
  pinMode(clockPin, OUTPUT);
  pinMode(dataPin, OUTPUT);
  Serial.begin(9600);
 
  lc1.shutdown(0,false);
  lc1.setIntensity(0,10);  
  lc1.clearDisplay(0);

  #ifndef ESP8266
  while (!Serial); // for Leonardo/Micro/Zero
#endif

delay(3000); // wait for console opening

if (! rtc.begin()) {
    Serial.println("Couldn't find RTC");
    while (1);
  }
//rtc.adjust(DateTime(__DATE__, __TIME__));
  if (rtc.lostPower()) {
    Serial.println("RTC lost power, lets set the time!");
    // following line sets the RTC to the date & time this sketch was compiled
    rtc.adjust(DateTime(__DATE__, __TIME__));
    // This line sets the RTC with an explicit date & time, for example to set
    // January 21, 2014 at 3am you would call:
    // rtc.adjust(DateTime(2014, 1, 21, 3, 0, 0));
  }
 
}

void loop() 
{     
     Colck();
               
}

void Colck()
{
  bool dot=true;
  while(true)
     {
        DateTime now = rtc.now();
        int hours=now.hour();
        if(hours > 12)
            hours = hours - 12;
        int mints=now.minute();
        
        int hours2=  hours/ 10;      
        int hours1= hours - (hours2 * 10 );

         int mints2=  mints / 10;      
        int mints1= mints - (mints2 * 10 );  
        
        
        lc1.setDigit(0,0,hours2,dot);
        lc1.setDigit(0,1,hours1,dot);
        lc1.setDigit(0,2,mints2,dot);
        lc1.setDigit(0,3,mints1,dot);
        //
        dot=!dot;
        delay(1000); 
        //Serial.print(now.hour(), DEC);
        Serial.println(__TIME__);
      } 
}


  

