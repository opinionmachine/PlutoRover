# PlutoRover
Move stuff around in a coordinate system

Create a Rover specifying initial position and cardinal direction ('N', 'E, 'S', 'W') and optionally the size of the coordinate system. 
100x100 is default.

Send a command by calling the Move method which takes a string. 

Valid instructions are 'F' for forward, 'B' for backward, 'R' for right hand turn, and 'L' for left hand turn. 

Invalid instructions and directions will be ignored silently. 
