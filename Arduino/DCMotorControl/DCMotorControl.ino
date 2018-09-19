#include <SPI.h> 

int enablePin = 6;
int in1Pin = 3;
int in2Pin = 4;
boolean direction= HIGH;

 
void setup()
{
  Serial.begin(9600);
  pinMode(in1Pin, OUTPUT);
  pinMode(in2Pin, OUTPUT);
  pinMode(enablePin, OUTPUT);
 
}
 
void loop()
{
  Serial.println("setMotor HIGH");
  for(int n=0 ; n < 500;n++ )
  {    
    int speed = 1000;    
    setMotor(speed, direction);  
  }  
  setMotor(0, direction); 
  delay(2000);    
  direction = !direction;
}
 
void setMotor(int speed, boolean reverse)
{  
 
    Serial.println("HIGH");
    digitalWrite(in1Pin, reverse);
    digitalWrite(in2Pin, !reverse);  
  
    analogWrite(enablePin, speed);
}
