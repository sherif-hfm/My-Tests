#include <SPI.h>
#include <RF24.h>
 
    RF24 radio(9,10);
 
    const uint64_t pipes[2] = { 0xF0F0F0F0E1LL, 0xF0F0F0F0D2LL };
    unsigned long Command = 1;
    int counter=0;
    int data[10];
    void setup()
    {
      Serial.begin(9600);   
      radio.begin();
      radio.setRetries(15,15);    
      radio.openWritingPipe(pipes[0]);    
    }
 
    void loop(void)
    {
      Serial.print("Send "); 
      for(int index=0 ; index < 10 ; index++)
      {
        data[index]=random(0,1000);        
        Serial.print( "index[" + String(index)+ "] = (" + String(data[index]) + ") ");
      }     
      Serial.println("");  
      radio.write( &data, sizeof(data) );   
      //radio.write( &counter, sizeof(counter) );         
      delay(1000);
      counter++;
    }
