#include <SPI.h>
#include <RF24.h>
 
    RF24 radio(9,10); 
    const uint64_t pipe =  0xF0F0F0F0E1;
    int data[10];
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
          int counter=0;          
          radio.read( &data, sizeof(data) );
          //radio.read( &counter, sizeof(counter) );
          Serial.print("Receive ");
          for(int index=0 ; index < 10 ; index++) 
            Serial.print( "index[" + String(index)+ "] = (" + String(data[index]) + ") ");
          //Serial.print(String(counter));
          Serial.print(" OK ");     
          Serial.println("");
          delay(500);
        }      
    }
