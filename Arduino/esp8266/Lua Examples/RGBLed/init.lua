  -- 1 second duration for timer

-- Initialising pin

gpio.mode(5, gpio.OUTPUT)
gpio.write(5, gpio.LOW)

gpio.mode(6, gpio.OUTPUT)
gpio.write(6, gpio.LOW)

gpio.mode(7, gpio.OUTPUT)
gpio.write(7, gpio.LOW)

local tmrled = tmr.create()

local status=0

local pin=7

function led()
    if status == 1 then
        pwm.stop(pin) 
        pwm.close(pin)
        status=0
    else
        pwm.setup(pin, 100, 255)  
        pwm.start(pin) 
        status=1
    end
    tmrled:register(1000,tmr.ALARM_SINGLE, led) 
    tmrled:start()
end 
-- Create an interval
tmrled:register(1000,tmr.ALARM_SINGLE, led) 
tmrled:start()