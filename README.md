# BEV4 `(v4.3)`

 BasicEventViewer v4 in may 2022 Updated for ver (.NET 4.5) , Published by Damon Mohammadbagher.

 ```diff 
 + last source/exe update(3) v4.3.202.158 [Aug 12, 2022]... , 
 + Null Exception Error for Events Loading fixed & some bugs in Real-time monitor fixed too.
 ```
 
 BEV4 is Event Monitor tool (real-time & search) some simple things like Atomic-red-team yaml file added for test & Real time detection for some type of attack and ...
 
 Note: in this code some yaml files (atomic-red-team yaml files) added to source code as "Database" for Search in Sysmon Event ID 1 Logs (real-time & search), so this code was for test and my database in this code is not good for detect everything but my tests was very good for some attack detection (real-time) , this code was for test and you can make your own code for real-time scanning Sysmon Events or ETW Events for Attack Detections based on Windows Events or ETW/Sysmon Events etc. you can load and watch my database in this tool and in this code All command prompts or powershell scripts will detect based on Yaml files information etc. (if you want use this database you really should change some rows in this DataBase, i did not change any thing in these yaml files , i just test them for some detection tests and results was good!).
 

Video1 for BEV4: https://www.youtube.com/watch?v=imU82TApG2k

Video2 for BEV4: https://www.youtube.com/watch?v=Hera3z1T5mI

Important point: About Mitre Attack Detections This code [BEV4 (v4.0)] is/was my test codes (which i will publish here....) to use some Mitre Attacks Techniques (Using Atomic red-team) yaml files just for test & help to Blue teamers to learn these things better, BEV4 test is/was very good in my opinion but ofcourse i know this will not Detect every thing but this is very good example to start for Attack Detection based on Some Mitre Attack Data (using Sysmon EID 1 ONLY in my code) + yaml files & .... , you can see every Technique has steps (Procedures) which in my code BEV4 these steps or Procedures will detect by Sysmon EID 1 (commandLine) or ETW events (CommandLine) etc, in my code i created one simple "Techniques Database" which has all steps (Procedures) for each Technique (created base on yaml file for Atomic-Red-Team). that means in my DB i have technique A with 3 lines CommandLine and my code will Detected each commandline and scan them for detection for each Sysmon/ETW events, and make score for each detection but this is not enough for very good detection (which i learned this when i make this BEV4.0 ;D ) , because always you can bypass some detection very simple (sometimes), so if you think yaml file or Mitre Attack is enough always, you are wrong (i am sure 100% about this even before make this code) but Mitre Attack is very useful thing in my opinion and as i said before "Mitre Attack is/Can not Cover Everything...", anyway this code was fun also i learned alot from yaml files (atomic-red-team) + Mitre Attack things but i am sure this (my code) will not cover all things etc this just is for test.... also about Steps (Procedures) for Each Techniques you always can bypass detection, why? because always you can!

so about "Techniques vs Procedures" this video is very good and i am agree with almost all things in this video honestly i don't know this guy (which does not matter) and i don't talk about their own tools or something like that, but this video and things which talked about that like (Techniques vs Procedures) is very good/useful for those Red-teamers/Pentesters which want to work with Blue teamers to make something for Detection (Purple Teaming) also this video is very good for all blue teamers too. btw i will publish my code and hopes to helpful for some of you to make your own detection better than before ;) why not?

video link : https://youtu.be/MHfGIY2IyXE?t=414


----------------------------------------------------------
###  BEV4 v4.3.200.138 [Jul 19, 2022].(BEV4 All Detection now saved into windows Eventlog Name [BEV4.3])
   ![](https://github.com/DamonMohammadbagher/BEV4/blob/main/Pics/BEV4_14.png)

###  BEV4 v4.3.194.120 [Jul 12, 2022].(BEV4 Event viewer)
   ![](https://github.com/DamonMohammadbagher/BEV4/blob/main/Pics/BEV4_1.png)
   
###  BEV4 v4.3.194.120 .(BEV4 Load/Export Events to HTML/CSV or Load Events into BEV4 tool)
   ![](https://github.com/DamonMohammadbagher/BEV4/blob/main/Pics/BEV4_2.png)  

###  BEV4 v4.3.194.120 .(BEV4 Sysmon EID 1 Events Load/Search by Mitre Attack yaml file [atomic-red-team])
   ![](https://github.com/DamonMohammadbagher/BEV4/blob/main/Pics/BEV4_3.png)  
   
###  BEV4 v4.3.194.120 .(BEV4  Load/Save, Search History)
   ![](https://github.com/DamonMohammadbagher/BEV4/blob/main/Pics/BEV4_4.png)  
   
###  BEV4 v4.3.194.120 .(BEV4 RealTime Monitoring Sysmon EID 1 and Mitre Attack Detection based on yaml files)
   ![](https://github.com/DamonMohammadbagher/BEV4/blob/main/Pics/BEV4_13.png)     
   
###  BEV4 v4.3.194.120 .(BEV4 Mitre Attack Detection, Database)
   ![](https://github.com/DamonMohammadbagher/BEV4/blob/main/Pics/BEV4_6.png)  
   
###  BEV4 v4.3.194.120 .(BEV4 Log Auditing)
   ![](https://github.com/DamonMohammadbagher/BEV4/blob/main/Pics/BEV4_7.png) 
   
###  BEV4 v4.3.194.120 .(BEV4 Log Auditing)
   ![](https://github.com/DamonMohammadbagher/BEV4/blob/main/Pics/BEV4_8.png)    
   
###  BEV4 v4.3.194.120 .(BEV4 Respond Analysis)
   ![](https://github.com/DamonMohammadbagher/BEV4/blob/main/Pics/BEV4_9.png)    
   
###  BEV4 v4.3.194.120 .(BEV4 Security log Filtering by Text)
   ![](https://github.com/DamonMohammadbagher/BEV4/blob/main/Pics/BEV4_11.png)    
   
###  BEV4 v4.3.194.120 .(BEV4 Security log Filtering by Security Event IDs)
   ![](https://github.com/DamonMohammadbagher/BEV4/blob/main/Pics/BEV4_12.png)    
   
   
   
   
<p><a href="https://hits.seeyoufarm.com"><img src="https://hits.seeyoufarm.com/api/count/incr/badge.svg?url=https://github.com/DamonMohammadbagher/BEV4/"/></a></p>
