--SSID    = "SherifHome.Net"
--APPWD   = "A@1234567890"

SSID    = "TP-LINK_BD08"
APPWD   = "B1234567890"


local tmrcheckWIFI = tmr.create()
local tmrWifiStatus = tmr.create()
local tmrRequest = tmr.create()

function IsConnected()
    ipAddr = wifi.sta.getip()
    if ( ( ipAddr == nil ) or ( ipAddr == "0.0.0.0" ) ) then        
        print("Not Connected")
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

 function MakeGetRequest()
     print("--MakeGetRequest")  
     if IsConnected() == true then
         http.get("http://192.168.1.12/cgi-bin/minerStatus.cgi",nil, 
          function(code, data)
            if (code < 0) then
              print("HTTP request failed " ..code)
            else
              print(code)
              --print(data)
            end
            tmrRequest:start()
          end)         
     end     
 end 
 
print("-- Starting up! ")

wifi.eventmon.register(wifi.eventmon.STA_CONNECTED, OnConnect)
wifi.eventmon.register(wifi.eventmon.STA_GOT_IP, OnGotIP)
wifi.eventmon.register(wifi.eventmon.AP_STADISCONNECTED, OnDisconnect)

Connect()

--tmrcheckWIFI:register(30000 , tmr.ALARM_AUTO , checkWIFI )
--tmrcheckWIFI:start()

tmrRequest:register(5000 , tmr.ALARM_SEMI , MakeGetRequest )
--tmrRequest:start()




