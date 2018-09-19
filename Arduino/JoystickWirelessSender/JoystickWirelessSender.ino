#include <SPI.h>
#include <RF24.h>

RF24 radio(9,10); 
const uint64_t pipe=  0xF0F0F0F0E1;

const int SW_pin = 4; // digital pin connected to switch output
const int X_pin = 0; // analog pin connected to X output
const int Y_pin = 1; // analog pin connected to Y output

int switchValue=1;
int xValue=500;
int yValue=500;
int isNewValues=0;
       
int data[10];
void setup()
{
  Serial.begin(9600);   
  radio.begin();
  radio.setRetries(15,15);    
  radio.openWritingPipe(pipe);    
  
  pinMode(SW_pin, INPUT);
  digitalWrite(SW_pin, HIGH);
}
 
void loop(void)
{
  readJoystickData();
  data[0]=switchValue;
  data[1]=xValue;
  data[2]=yValue;
  ShowData();
  if(isNewValues == 1)
    radio.write( &data, sizeof(data) );
  //radio.write( &counter, sizeof(counter) );         
  delay(50);
  
}

void readJoystickData()
{
  int newSwitchValue = digitalRead(SW_pin);
  int newXValue = analogRead(X_pin);
  int newYValue = analogRead(Y_pin);
  /*if(newSwitchValue == switchValue && abs(xValue - newXValue) < 20   && abs(yValue - newYValue) < 20 )
    isNewValues = 0 ;
   else   */
      isNewValues=1;
  switchValue = newSwitchValue;
  xValue = newXValue;
  yValue = newYValue;
      
}

void ShowData()
{
  Serial.print("switch=" + String(switchValue) + "    xValue=" + String(xValue) + "     yValue=" + String(yValue));  
  Serial.println("");
}

