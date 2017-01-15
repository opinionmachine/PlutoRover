namespace PlutoRover

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

    member private this.goForward() =
        match d with 
        |   'N' -> y <- y + 1
        |   'E' -> x <- x + 1
        |   'W' -> x <- x - 1
        |   'S' -> y <- y - 1
        |   _   -> ()

    member private this.dispatch(commandlist) =
        match commandlist with
        |   'F'::rest -> 
            this.goForward()
            this.dispatch(rest)
        |   'B'::rest -> 
            y <- y - 1
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
