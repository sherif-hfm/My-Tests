#include <LedControl.h>
#include <binary.h>



// http://www.ithepro.com/2015/11/kyx-5461as-4-digit-7-segment-led.html
// http://playground.arduino.cc/Main/LedControl


int latchPin = 10;
int clockPin = 11;
int dataPin = 12;

LedControl lc1=LedControl(dataPin,clockPin,latchPin,1);


void setup()
{
 pinMode(latchPin, OUTPUT);
  pinMode(clockPin, OUTPUT);
  pinMode(dataPin, OUTPUT);
  Serial.begin(9600);
 
  lc1.shutdown(0,false);
  lc1.setIntensity(0,10);  
  lc1.clearDisplay(0);

  
 
}

void loop() 
{     
     //Counter();
               
}

void Counter()
{
  //lc1.setRow(0,0,B11111111);
     //lc1.setRow(0,1,B11111111);
  bool dot=true;
  for(int count=0 ; count <=9999 ; count++)
     {      
        int thou= (count/1000 );
        int hnds=  (count-(thou*1000)) /100;
        int thens= (count-(thou*1000)-(hnds*100)) /10;
        int ones= (count-(thou*1000)-(hnds*100)-(thens*10)) ;
        lc1.setDigit(0,0,thou,dot);
        lc1.setDigit(0,1,hnds,dot);
        lc1.setDigit(0,2,thens,dot);
        lc1.setDigit(0,3,ones,dot);
        //
        dot=!dot;
        delay(100); 
      } 
}


  

