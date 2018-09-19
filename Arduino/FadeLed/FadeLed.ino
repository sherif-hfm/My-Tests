int led11 = 11;           // the PWM pin the LED is attached to
int brightness11 = 0;
int brightness10 = 20;
int brightness09 = 40;// how bright the LED is
int brightness08 = 60;// how bright the LED is
int fadeAmount11 = 2;    // how many points to fade the LED
int fadeAmount10 = 2; 
int fadeAmount09 = 2; 
int fadeAmount08 = 2;  
void setup() {
  // put your setup code here, to run once:
 pinMode(11, OUTPUT);
 pinMode(10, OUTPUT);
 pinMode(9, OUTPUT);
 pinMode(6, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  
    analogWrite(11, brightness11);
    analogWrite(10, brightness10);
    analogWrite(9, brightness09);
    analogWrite(6, brightness08);

  // change the brightness for next time through the loop:
  brightness11 = brightness11 + fadeAmount11;
  brightness10 = brightness10 + fadeAmount10;
  brightness09 = brightness09 + fadeAmount09;
  brightness08 = brightness08 + fadeAmount08;

  // reverse the direction of the fading at the ends of the fade:
  if (brightness11 <= 0 || brightness11 >= 200) {
    fadeAmount11 = -fadeAmount11 ;
  }
    if (brightness10 <= 0 || brightness10 >= 200) {
    fadeAmount10 = -fadeAmount10 ;
    }
    if (brightness09 <= 0 || brightness09 >= 200) {
    fadeAmount09 = -fadeAmount09 ;
    }
    if (brightness08 <= 0 || brightness08 >= 200) {
    fadeAmount08 = -fadeAmount08 ;
  }
  // wait for 30 milliseconds to see the dimming effect
  delay(10);
      
}
