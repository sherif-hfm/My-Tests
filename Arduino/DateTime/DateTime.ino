#include <Time.h>
#include <TimeLib.h>

//http://playground.arduino.cc/Code/Time
bool isTimeSet;
void setup() {
  // put your setup code here, to run once:
Serial.begin(9600);
isTimeSet=false;
}

void loop() {
  // put your main code here, to run repeatedly:
  if(isTimeSet == false)
  {
      SetDate();
      isTimeSet=true;
    }
  
  Serial.print("Time : " + GetDate());
  delay(1000);
}

void SetDate()
{
  setTime(16,55,0,16,6,2016);  
  }

String GetDate()
{
  time_t t = now();
  String crTime= String(second(t)) + ":" + String(minute(t)) + ":" + String(hour(t)) ;
  return crTime;
  }
