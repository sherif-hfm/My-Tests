SSID    = "SherifHome.Net"
APPWD   = "A@1234567890"
CMDFILE = "ping.lua"  
errCounter=0
canRestart=false
ledStatus=0
ReqStatus=0  -- 0 try connect 1 connected 2 ok 3 error

local tmrled = tmr.create()
local tmrcheckWIFI = tmr.create()
local tmrMakeGetRequest = tmr.create()
local tmrReset = tmr.create()


function ResetLeds() 
    gpio.mode(5, gpio.OUTPUT)
    gpio.write(5, gpio.LOW)
    pwm.stop(5) 
    pwm.close(5)
    
    gpio.mode(6, gpio.OUTPUT)
    gpio.write(6, gpio.LOW)
    pwm.stop(6) 
    pwm.close(6)
    
    gpio.mode(7, gpio.OUTPUT)
    gpio.write(7, gpio.LOW)
    pwm.stop(7) 
    pwm.close(7)
end


function Led()
    if ledStatus==1  then
        ledStatus=0        
        if ReqStatus == 0 then
            pwm.setup(6, 100, 255)  
            pwm.start(6)
            pwm.setup(7, 100, 255)  
            pwm.start(7)
            pwm.setup(5, 100, 255)  
            pwm.start(5)
        end
        if ReqStatus == 1 then
            pwm.setup(7, 100, 255)  
            pwm.start(7)
        end
        if ReqStatus == 2 then
            pwm.setup(6, 100, 50)  
            pwm.start(6)
        end
        if ReqStatus == 3 then
            pwm.setup(5, 100, 255)  
            pwm.start(5)
        end
    else
        ledStatus=1
        ResetLeds()
    end     
end

function ResetPc()     
    if errCounter > 24 and canRestart == true then
        print("ResetPc")        
         canRestart = false
         gpio.mode(2, gpio.OUTPUT)
         gpio.write(2, gpio.HIGH)         
         tmrReset:register(1000 , tmr.ALARM_SINGLE , 
         function()
            gpio.write(2, gpio.LOW)            
         end)
        tmrReset:start()
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
   ReqStatus=0
   canRestart=false
   Connect()  
end

function OnConnect(T) 
   print("Connected to WIFI!")  
end

function OnGotIP(T) 
   print("IP Address: " .. wifi.sta.getip())
   ReqStatus=1
end

function checkWIFI()
    print("-- checkWIFI ")    
    ipAddr = wifi.sta.getip()
    if ( ( ipAddr == nil ) or  ( ipAddr == "0.0.0.0" ) ) then
        ReqStatus=0
        Connect()
    end    
end

 function MakeGetRequest()   
   ipAddr = wifi.sta.getip()
   if ( ( ipAddr ~= nil ) and  ( ipAddr ~= "0.0.0.0" ) ) then
   print("MakeGetRequest")  
    http.get("http://192.168.2.10/", nil, function(code, data)
            if (code < 0) then
               print("HTTP request failed")
               errCounter= errCounter + 1
               ReqStatus=3
               ResetPc()               
            else                
                errCounter=0
                canRestart=true            
                ReqStatus=2
            end
        end)
    end   
 end 
 
print("-- Starting up! ")

ReqStatus=0
ResetLeds()

wifi.eventmon.register(wifi.eventmon.STA_CONNECTED, OnConnect)
wifi.eventmon.register(wifi.eventmon.STA_GOT_IP, OnGotIP)
wifi.eventmon.register(wifi.eventmon.AP_STADISCONNECTED, OnDisconnect)

tmrcheckWIFI:register(20000 , tmr.ALARM_AUTO , checkWIFI )
tmrcheckWIFI:start()

Connect()

tmrMakeGetRequest:register(5000 , tmr.ALARM_AUTO , MakeGetRequest )
tmrMakeGetRequest:start()

tmrled:register(1000 , tmr.ALARM_AUTO , Led )
tmrled:start()

