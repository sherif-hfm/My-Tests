
#include <Arduino.h>
#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>


//ESP8266WiFiMulti WiFiMulti;

void setup() {
  Serial.begin(115200);
  delay(5000);  
  WiFi.mode(WIFI_STA);
  WiFi.begin("SherifHome.Net", "A@1234567890");
  log("Connecting");
  while (WiFi.status() != WL_CONNECTED)
  {
    delay(500);
    log(".");
  }
  Serial.println("Connected");
  log("IP address: " + WiFi.localIP());  
}

void loop() {
  // wait for WiFi connection
  if ((WiFi.status() == WL_CONNECTED)) {
    HTTPClient http;
    log("[HTTP] begin...");    
    http.begin("http://192.168.2.10/"); 
    log("[HTTP] GET...");    
    int httpCode = http.GET();    
    if (httpCode > 0) {      
      log("[HTTP] GET... code: " + httpCode);      
      if (httpCode == HTTP_CODE_OK) {
          Serial.write('0');
      }
    } 
    else 
    {
      Serial.write('1');      
    }
    http.end();
  }
  delay(5000);
}

void log(String _log)
{
  return;
  Serial.println(_log);
}


