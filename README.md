# Other_small_programs
Study projects

---------------------------------------------------------------
Pressure_indicator_graph, Speed_indicator_graph - simple indicators:
you can set input signal and check painted result

---------------------------------------------------------------
Stack_based_class - slightly enhanced stack with dates and value control

---------------------------------------------------------------
Clock - different clock indicators that can be painted

---------------------------------------------------------------
Temperature_indicator - similar to Clock project. Contains different thermometers

---------------------------------------------------------------
University_timetable - OOP oriented app without database. Stores info about lessons, time, free rooms, etc.

---------------------------------------------------------------
Crossroads_model - visual model of a crossroads with roadlights.
Cars drive when they are allowed to

---------------------------------------------------------------
Simple_c_shell - basic custom shell in C.
Available commands:

cd PATH          //go to a new directory PATH

pwd          //current path

ls [PATH]          //current dir or dir with path=PATH

strmsg [MESSAGE]      //set message shown in every line MESSAGE>

other commands: will be sent to system shell, returns back after running outer command

---------------------------------------------------------------
Movement detector (takes video stream)

requirements:

Python, OpenCV, NumPy

usage:

Movement_detector.py             =               capture video from camera, detect movement with static or slightly moving background

Movement_detector.py videofile.mp4       =       detect movement in video file 

DIVIDER constant sets the min required moving object size share (DIVIDER=5 -> 20% of image has to move)

alarms when something is moving; writes log; counts the length of movement is seconds and frames; detects large moving objects 

---------------------------------------------------------------
MarkerDetector

requirements:

Python, OpenCV, NumPy

usage: 
set parameters and run
OR
use the MovementDetector class in your app

Detects square markers. Marker has to have dark borders and bright center.

Output example is given in result.png file. Sample markers are in MARKERS.png