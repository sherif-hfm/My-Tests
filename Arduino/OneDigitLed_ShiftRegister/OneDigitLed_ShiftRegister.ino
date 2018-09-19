
//Pin connected to ST_CP of 74HC595
int latchPin = 8;
//Pin connected to SH_CP of 74HC595
int clockPin = 12;
////Pin connected to DS of 74HC595
int dataPin = 11;

void setup()
{
   //set pins to output so you can control the shift register
  pinMode(latchPin, OUTPUT);
  pinMode(clockPin, OUTPUT);
  pinMode(dataPin, OUTPUT);
  Serial.begin(9600);
 
}

void loop() {  
  //if (Serial.available() > 0) {
      // read the incoming byte:
      //String incomingByte = Serial.readString();
      for(int num=0 ; num <=9 ; num++)
      {
          // take the latchPin low so 
          // the LEDs don't change while you're sending in bits:
          digitalWrite(latchPin, LOW);
          // shift out the bits:
          //shiftOut(dataPin, clockPin, MSBFIRST, EncodeNumber(incomingByte.toInt()));  
          shiftOut(dataPin, clockPin, MSBFIRST, EncodeNumber(num));
          //take the latch pin high so the LEDs will light up:
          digitalWrite(latchPin, HIGH);
          // pause before next value:
          delay(500);
          
          // say what you got:
          //Serial.print("I received: ");
          //Serial.print(String(incomingByte));
      }
        //}         
  }

  int EncodeNumber(int _code)
  {
    switch (_code) {
      case 0:
        return 126;
      case 1:
        return 18;
     case 2:
        return 61;
     case 3:
        return 109;
      case 4:
        return 75;
      case 5:
        return 103;
      case 6:
        return 119;
      case 7:
        return 76;
      case 8:
        return 127;
      case 9:
        return 111;      
      default: 
        return 0;
    }
  }
  

