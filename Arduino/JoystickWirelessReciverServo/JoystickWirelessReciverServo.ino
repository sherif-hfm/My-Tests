#include <SPI.h>
#include <RF24.h>
#include <Servo.h>
 
RF24 radio(9,10); 
const uint64_t pipe=  0xF0F0F0F0E1;
int data[10];

int switchValue=1;
int xValue=500;
int yValue=500;

Servo servo;
int servoPin = 7;  
int servoAngle = 0;
int newAngle=0;
void setup(void)
{
  servo.attach(servoPin);
        
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
      radio.read( &data, sizeof(data));    
      switchValue=data[0];
      xValue=data[1];
      yValue=data[2];
      newAngle=CalcServoNewAngle();
      MoveServo(newAngle);
      ShowData();
      delay(10);
    }      
}

int CalcServoNewAngle()
{
  int _newAngle=(int)(xValue / 5.6);
  if(_newAngle <= 20 )
    _newAngle = 20;
  return _newAngle;  
}

void MoveServo(int _newAngle)
{  
  if(_newAngle > (servoAngle + 20) || _newAngle < (servoAngle - 20))
  {
      servo.write(_newAngle);
      servoAngle=_newAngle;
  }
}

void ShowData()
{
  Serial.print("switch=" + String(switchValue) + "    xValue=" + String(xValue) + "     yValue=" + String(yValue) + "      servoAngle=" + String(servoAngle));  
  Serial.println("");
}
