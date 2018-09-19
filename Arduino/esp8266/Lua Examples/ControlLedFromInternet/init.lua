SSID    = "SherifHome.Net"
APPWD   = "A@1234567890"
CMDFILE = "ping.lua"   -- File that is executed after connection
pin = 7            --  GPIO13

function Connect(T) 
  print("Configuring WIFI....")
  wifi.setmode( wifi.STATION )
  station_cfg={}
  station_cfg.ssid=SSID
  station_cfg.pwd=APPWD
  station_cfg.save=false
  wifi.sta.config( station_cfg )
  print("Waiting for connection")
end

function OnDisconnect(T) 
   print("Disconnect WIFI!")
   Connect()  
end

function OnConnect(T) 
   print("Connected to WIFI!")  
end

function OnGotIP(T) 
   print("IP Address: " .. wifi.sta.getip())
end

function checkWIFI()
    print("-- checkWIFI ")    
    ipAddr = wifi.sta.getip()
    if ( ( ipAddr == nil ) or  ( ipAddr == "0.0.0.0" ) ) then
        Connect()
    end  
    tmr.alarm( 0 , 10000 , tmr.ALARM_SINGLE , checkWIFI )
end

 function MakeGetRequest()
 --http://45.35.4.147:6010/RegsApi/SetDeviceStatus/Reg11/0
   ipAddr = wifi.sta.getip()
   if ( ( ipAddr ~= nil ) and  ( ipAddr ~= "0.0.0.0" ) ) then
    http.get("http://45.35.4.147:6010/RegsApi/GetDeviceStatus/Reg11", nil, function(code, data)
            if (code < 0) then
              print("HTTP request failed")
            else              
              print(code,data)              
              if(data == "1") then
                gpio.write(pin, gpio.HIGH)
              else
                gpio.write(pin, gpio.LOW)
              end 
            end
        end)
    end
    tmr.alarm( 0 , 5000 , tmr.ALARM_SINGLE , MakeGetRequest )
 end 
 
print("-- Starting up! ")

wifi.eventmon.register(wifi.eventmon.STA_CONNECTED, OnConnect)
wifi.eventmon.register(wifi.eventmon.STA_GOT_IP, OnGotIP)
wifi.eventmon.register(wifi.eventmon.AP_STADISCONNECTED, OnDisconnect)

gpio.mode(pin, gpio.OUTPUT)
gpio.write(pin, gpio.LOW)

tmr.alarm( 0 , 1000 , tmr.ALARM_SINGLE , checkWIFI )
tmr.alarm( 1 , 5000 , tmr.ALARM_SINGLE , MakeGetRequest )

