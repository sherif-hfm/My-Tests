#include <SPI.h>
#include <RF24.h>
 
RF24 radio(9,10); 
const uint64_t pipe=  0xF0F0F0F0E1;
int data[10];

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
      radio.read( &data, sizeof(data));    
      switchValue=data[0];
      xValue=data[1];
      yValue=data[2];
      ShowData();
      delay(10);
    }      
}

void ShowData()
{
  Serial.print("switch=" + String(switchValue) + "    xValue=" + String(xValue) + "     yValue=" + String(yValue));  
  Serial.println("");
}
