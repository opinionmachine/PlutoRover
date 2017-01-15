﻿namespace PlutoRover

type Rover(x0, y0 ,d0) = 
    let mutable x = x0
    let mutable y :int = y0
    let mutable d = d0
    member private this.turnRight() =
        match d with
        |   'N' -> d <- 'E'
        |   'E' -> d <- 'S'
        |   'S' -> d <- 'W'
        |   'W' -> d <- 'N'
        |   _  -> ()

    member private this.turnLeft() =
        match d with
        |   'N' -> d <- 'W'
        |   'W' -> d <- 'S'
        |   'S' -> d <- 'E'
        |   'E' -> d <- 'N'
        |   _  -> ()

    member private this.go(step) =
        match d with 
        |   'N' -> y <- y + step
        |   'E' -> x <- x + step
        |   'W' -> x <- x - step
        |   'S' -> y <- y - step
        |   _   -> ()

    member private this.dispatch(commandlist) =
        match commandlist with
        |   'F'::rest -> 
            this.go(1)
            this.dispatch(rest)
        |   'B'::rest -> 
            this.go(-1)
            this.dispatch(rest)
        |   'R'::rest -> 
            this.turnRight()
            this.dispatch(rest)
        |   'L'::rest -> 
            this.turnLeft()
            this.dispatch(rest)
        |   [] -> ()
        |   rest -> this.dispatch(rest)
        
    member this.Move(commands: string) = 
        this.dispatch(commands |> Seq.toList)
        (x, y, d)
