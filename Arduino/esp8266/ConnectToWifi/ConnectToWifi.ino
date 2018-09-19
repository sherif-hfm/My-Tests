#include <ESP8266WiFi.h>
void setup()
{
  Serial.begin(115200);
  delay(5000);
  Serial.println();

  WiFi.begin("SherifHome.Net", "A@1234567890");

  Serial.print("Connecting");
  while (WiFi.status() != WL_CONNECTED)
  {
    delay(500);
    Serial.print(".");
  }
  Serial.println();

  Serial.print("Connected, IP address: ");
  Serial.println(WiFi.localIP());
}

void loop() {
  if ((WiFi.status() == WL_CONNECTED)) {
  Serial.print("Connected, IP address: ");
  Serial.println(WiFi.localIP());
  }
  delay(5000);
  }

