int redPin = 9;
int greenPin = 10;
int bluePin = 11;
int transistorPin=8;
int errCounter=0;
bool canRestart=false;
bool ConnectStatus=false;
void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  pinMode(redPin, OUTPUT);
  pinMode(greenPin, OUTPUT);
  pinMode(bluePin, OUTPUT);
  pinMode(transistorPin, OUTPUT); 
}

void loop() {
  // put your main code here, to run repeatedly:
  WaitForConnected();
  int serverStatus = GetServerStatus();
  
  if(serverStatus == 0)
  {
          ledOk();//Serial.println("0");
          errCounter=0;
          canRestart=true;
  }  
  if(serverStatus == 1)
  {
      errCounter++;
      ledError();//Serial.println("1");  
  }
  
  
  if(errCounter > 10 && canRestart==true)
    RestartPc();
  
  delay(1000);
  ledOff();
}

void RestartPc()
{
  errCounter=0;
  canRestart=false;
  digitalWrite(transistorPin, HIGH);
  delay(1000);
  digitalWrite(transistorPin, LOW);
}

int GetServerStatus()
{
    String inData;
    if(Serial.available())
    {
      inData = Serial.readString();
      //Serial.println(inData);
      if(inData == "1" || inData=="0")
      {
          if(inData == "1")
            return 1;
          if(inData == "0")
            return 0;
      }
      else
           ConnectStatus=false;     
    }
    return -2;
}

void WaitForConnected()
{
  String inData;
  while(!ConnectStatus) 
  {
      ledTryConnect(); //Serial.println("WaitForConnected");
      if(Serial.available())
      {
          inData = Serial.readString();
          if(inData.indexOf("Connected") > -1)
          {
            ConnectStatus=true;
            ledConnected();//Serial.println("Connected Done");            
          }              
      }
    delay(500);    
   }   
}

void ledOff()
{
  analogWrite(redPin, 0);
  analogWrite(greenPin, 0);
  analogWrite(bluePin, 0);
}

void ledTryConnect()
{
   analogWrite(redPin, 125);
  analogWrite(greenPin, 0);
  analogWrite(bluePin, 125); 
}

void ledConnected()
{
   analogWrite(redPin, 0);
  analogWrite(greenPin, 0);
  analogWrite(bluePin, 255); 
}

void ledOk()
{
   analogWrite(redPin, 0);
  analogWrite(greenPin, 1);
  analogWrite(bluePin, 0); 
}

void ledError()
{
   analogWrite(redPin, 255);
  analogWrite(greenPin, 0);
  analogWrite(bluePin, 0); 
}



