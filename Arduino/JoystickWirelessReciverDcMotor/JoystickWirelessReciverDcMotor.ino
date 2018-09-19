#include <SPI.h>
#include <RF24.h>
 
RF24 radio(9,10); 
const uint64_t pipe=  0xF0F0F0F0E1;
int data[10];

int enablePin = 6;
int in1Pin = 3;
int in2Pin = 4;
boolean direction= HIGH;
int speed = 0;
int switchValue=1;
int xValue=500;
int yValue=500;

void setup(void)
{
  Serial.begin(9600);  
  radio.begin();
  radio.setRetries(15,15);
  radio.openReadingPipe(1,pipe);
  radio.startListening();  
}
 
void loop(void)
{             
  if ( radio.available() )
  {
    Serial.println("Data Received");
    radio.read( &data, sizeof(data));    
    switchValue=data[0];
    xValue=data[1];
    yValue=data[2];    
    //delay(10);
  }
  CalcSpeed();
  setMotor(abs(speed) , direction);       
  ShowData();      
}

void CalcSpeed()
{  
  if(yValue > 600)
      speed = speed + 50;
   if(yValue < 400)
      speed = speed - 50;
   if(speed > 1000)
      speed= 1000;
   if(speed < 0 )
      direction= LOW;
   else
      direction= HIGH;
   if(switchValue == 0 )
   {
      speed= 0;
      yValue=500; 
   }
}
void setMotor(int _speed, boolean _direction)
{    
    digitalWrite(in1Pin, _direction);
    digitalWrite(in2Pin, !_direction);    
    analogWrite(enablePin, _speed);
}

void ShowData()
{
  Serial.print("switch=" + String(switchValue) + "    xValue=" + String(xValue) + "     yValue=" + String(yValue) + "      speed=" + String(speed));  
  Serial.println("");
}
