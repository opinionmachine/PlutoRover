namespace PlutoRover
open System

type ObstacleException(x, y) = 
    inherit Exception(String.Format("Obstacle encountered at {0}, {1}", x, y))
