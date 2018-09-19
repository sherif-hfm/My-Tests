SSID    = "SherifHome.Net"
APPWD   = "A@1234567890"
CMDFILE = "ping.lua"   -- File that is executed after connection

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
    ipAddr = wifi.sta.getip()
    if ( ( ipAddr == nil ) or  ( ipAddr == "0.0.0.0" ) ) then
        Connect()
    else
        --print("IP Address: " .. wifi.sta.getip())
        MakeGetRequest()
    end
    tmr.alarm( 0 , 10000 , tmr.ALARM_AUTO , checkWIFI )
end

 function MakeGetRequest()
    http.get("http://192.168.2.100/", nil, function(code, data)
    if (code < 0) then
      print("HTTP request failed")
    else
      reg="<div .*>%d+</div>"      
      reg2=">%d+<"
      div1=string.match(data,reg)
      --print(div1)
      print(string.match("div1 div2 div3",'div?'))
    end
  end)
 end 
 
print("-- Starting up! ")

wifi.eventmon.register(wifi.eventmon.STA_CONNECTED, OnConnect)
wifi.eventmon.register(wifi.eventmon.STA_GOT_IP, OnGotIP)
wifi.eventmon.register(wifi.eventmon.AP_STADISCONNECTED, OnDisconnect)

tmr.alarm( 0 , 1000 , tmr.ALARM_SINGLE , checkWIFI )

