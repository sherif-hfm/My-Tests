#include <IRremote.h>

int RECV_PIN = 11;

IRrecv irrecv(RECV_PIN);
decode_results results;
#define PWD 0x800FF
int status=0;

void setup()
{
  pinMode(10, OUTPUT);
  Serial.begin(9600);
  irrecv.enableIRIn(); // Start the receiver
}

void loop() {
  if (irrecv.decode(&results)) {
    if (results.value == PWD)  {
      switch (status) {
        case 0:
          digitalWrite(10, HIGH);
          status=1;        
          break;
        case 1:
          digitalWrite(10, LOW);
          status=0;        
          break;
     }        
      Serial.println("PWD"); 
    }       
    Serial.println(results.value, HEX);      
    irrecv.resume(); // Receive the next value
  }
  delay(100);
}
