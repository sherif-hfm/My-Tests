--SSID    = "SherifHome.Net"
--APPWD   = "A@1234567890"
SSID    = "TP-LINK_BD08"
APPWD   = "B1234567890"
pin = 7            --  GPIO13

local tmrcheckWIFI = tmr.create()
local tmrWebRequest = tmr.create()

url = "http://45.35.4.147:6010/RegsApi/GetDeviceStatus/Reg12"

function IsConnected()
    ipAddr = wifi.sta.getip()
    if ( ( ipAddr == nil ) or ( ipAddr == "0.0.0.0" ) ) then        
        return false
    else
        return true
    end 
end 

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
   tmrWebRequest:start()
end

function checkWIFI()
    print("-- checkWIFI ")    
    if ( IsConnected()==false ) then
        Connect()
    end      
end

function DeviceOn()
    gpio.mode(pin, gpio.OUTPUT)
    gpio.write(pin, gpio.LOW)
end 

function DeviceOff()
    gpio.mode(pin, gpio.OUTPUT)
    gpio.write(pin, gpio.HIGH)
end 

 function GetDeviceStatus()    
   if (IsConnected()==true) then
    http.get(url, nil, 
        function(code, data)
            if (code < 0) then
              print("HTTP request failed")              
            else              
              print(code,data)              
              if(data == "1") then
                DeviceOn()
              else
                DeviceOff()
              end 
            end            
        end)
    end    
 end 
 
print("-- Starting up! ")

wifi.eventmon.register(wifi.eventmon.STA_CONNECTED, OnConnect)
wifi.eventmon.register(wifi.eventmon.STA_GOT_IP, OnGotIP)
wifi.eventmon.register(wifi.eventmon.AP_STADISCONNECTED, OnDisconnect)

Connect()

tmrcheckWIFI:register(30000 , tmr.ALARM_AUTO , checkWIFI )
tmrcheckWIFI:start()

tmrWebRequest:register(5000 , tmr.ALARM_AUTO , GetDeviceStatus )
tmrWebRequest:start()


