int incomingByte = 0; 
String inData;
void setup() {
  // put your setup code here, to run once:
Serial.begin(9600);
}

void loop() {
  //if (Serial.available() > 0) {
                // read the incoming byte:
                //incomingByte = Serial.read();
                while(Serial.available()) {
                  inData = Serial.readString();  
                  // say what you got:
                  Serial.print("I received: ");
                  //Serial.println(incomingByte, DEC);
                  Serial.println(inData);  
                }                
    //    }        
delay(10);
}
