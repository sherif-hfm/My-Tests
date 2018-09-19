SSID    = "SherifHome.Net"
APPWD   = "A@1234567890"
CMDFILE = "ping.lua"   -- File that is executed after connection

local tmrcheckWIFI = tmr.create()
local tmrWifiStatus = tmr.create()

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
end

function checkWIFI()
    print("--checkWIFI ")        
    if IsConnected() == true then
        Connect()
    end    
end

function PrintWIFIStatus()    
    if IsConnected() == true then
        print("Not Connected ")
    else
        print("IP Address: " .. wifi.sta.getip())
    end    
end 
 
print("-- Starting up! ")

wifi.eventmon.register(wifi.eventmon.STA_CONNECTED, OnConnect)
wifi.eventmon.register(wifi.eventmon.STA_GOT_IP, OnGotIP)
wifi.eventmon.register(wifi.eventmon.AP_STADISCONNECTED, OnDisconnect)

Connect()

tmrcheckWIFI:register(10000 , tmr.ALARM_AUTO , checkWIFI )
tmrcheckWIFI:start()
tmrWifiStatus:register(2000 , tmr.ALARM_AUTO , PrintWIFIStatus )
tmrWifiStatus:start()


