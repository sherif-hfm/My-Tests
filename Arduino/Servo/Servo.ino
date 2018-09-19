#include <Servo.h>
#include <SPI.h> 

int servoPin = 7;
Servo servo;  
int servoAngle = 90;   // servo position in degrees
int newAngle = 90 ; 

void setup()
{
  Serial.begin(9600);
  servo.attach(servoPin);
}
 
 
void loop()
{
//control the servo's direction and the position of the motor
  if (Serial.available() > 0)
  {
      newAngle =  Serial.readString().toInt();
      Serial.println(String(newAngle));      
      servo.write(newAngle);
      servoAngle=newAngle;
  }
  delay(10);
}
