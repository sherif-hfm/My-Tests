/*
 ESP8266 Blink by Simon Peter
 Blink the blue LED on the ESP-01 module
 This example code is in the public domain
 
 The blue LED on the ESP-01 module is connected to GPIO1 
 (which is also the TXD pin; so we cannot use Serial.print() at the same time)
 
 Note that this sketch uses LED_BUILTIN to find the pin with the internal LED
*/
int count=0;
String outStr ="";
void setup() {
  Serial.begin(115200);  
  delay(5000);
}

// the loop function runs over and over again forever
void loop() {
  
  outStr =  "Count : " + String(count);
  //byte data[outStr.length() + 1];
  //outStr.getBytes(data, sizeof(data));
  Serial.println(outStr);    
  //Serial.write(data, sizeof(data));    
  count++;
  delay(1000);
}
