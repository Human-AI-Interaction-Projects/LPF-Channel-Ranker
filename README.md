# Channel_Select
# LFP channel detection and suggestion helper

## Content:
- Software requirement
- Demo Hardware requirement
- Practice Hardware requirement
- Hardware Setup
- Software Setup
- User Interface


# Software requirement:

- Windows 10, Version 1909
- Visual Studio 2019 installed

# Demo Hardware requirement:

-  MyoWare Muscle Sensor
![image info](./picture/sensor.jpg)
-  ECG Electrodes
![image info](./picture/pad.jpg)
-  USB - A/B Connector
-  ArduinoMega
![image info](./picture/ardu.jpg)

# Practice Hardware requirement:

1. UStim II device
2. 256 Channel Omettic Connector
3. Implanted Electrode array

# Hardware Setup
- Arduino and EMG Sensor are connected to common ground
- Signal pin from EMG Sensor is connected to A7 arduino adc pin
- EMG Sensor's power pin is connected to 5v DC power source

# Software Setup

### For First time Installation:
- Open Visual Studio 2019
- Open .sln file and run Visual Studio in debugging mode
- Change computer to developer mode


### After appPackage location is generated:
- Copy and move LocalState folder under folder 16a2373a-1519-4dca-8c90-ac84a72b4cfd_kbtfgvzxh186t\
- Application data is stored at 16a2373a-1519-4dca-8c90-ac84a72b4cfd_kbtfgvzxh186t\

### Arduino Software Setup:
- Make sure to close PC Application
- Connect Arduino to Arduino IDE through USB A/B connector
- Select correct PORT
- Select Arduino Mega for board spec
- Select Arduino Gamma for firmware

### Final Step:
- Close Arduino IDE
- Run Visual Studio in release mode
- Close Visual Studio
- Locate Channel_Select App in Windows search and Open the App

# User Interface

## Please click on following picture for Video Guide

[![](./picture/guidecover.PNG)](https://youtu.be/QNZgJIwNKKI)


## Starting Page:

![image info](./picture/newguid.PNG)

### Starting Page consists of 5 key component:
- Reference channel located at left top corner
- Configuration option located at left bottom corner
- Ranked output channel located at top right corner
- Feature configuration panel located at bottom right corner
- Start button located at bottom left corner

### Application:

#### Application allow user to select and draw on Reference channel
#### When drawing, Please make a complete circle inside the plotter boundary
![image info](./picture/newgui.PNG)

#### Application can display feature parameter visually to user
#### User are also allowed to choose their channel of desire to be displayed
![image info](./picture/present2.PNG)

#### Application allow user to change threshold on the run time
#### Threshold change will correpond to feature paramter change
#### Use the slider on the left to change threshold
![image info](./picture/newgui2.PNG)


# Reference
| Plugin | README |
| ------ | ------ |
| myoWare User Guide | [https://cdn.sparkfun.com/datasheets/Sensors/Biometric/MyowareUserManualAT-04-001.pdf] |
| Arduino User Guide | [https://www.arduino.cc/en/Reference/DataSheets] |
