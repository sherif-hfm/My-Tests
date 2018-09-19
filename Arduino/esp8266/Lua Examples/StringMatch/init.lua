

data='<html><body><h1>welcome to web</h1><div id="div1">1</div><span>33</span><div id="div2">22</div><h3>thanks</h3></body>'    
reg="<div .->(%d+)</div>"      
reg2=">%d+<"
--div1=string.match(data,reg)
--print(div1)
myData = ""
for w in string.gmatch(data, reg) do
myData = myData .. w .. ","
       print(w)
     end
print (myData)
print(string.match("div1 ## div2 ## div3",'.+'))
print("ok1")

 

