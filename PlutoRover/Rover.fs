namespace PlutoRover

type Rover(x0, y0 ,d0) = 
    let mutable x = x0
    let mutable y :int = y0
    let mutable d = d0
    member private this.turnRight() =
        match d with
        |   'N' -> d <- 'E'
        |   'E' -> d <- 'S'
        |   _  -> ()

    member private this.Dispatch(commandlist) =
        match commandlist with
        |   'F'::rest -> 
            y <- y + 1  
            this.Dispatch(rest)
        |   'B'::rest -> 
            y <- y - 1
            this.Dispatch(rest)
        |   'R'::rest -> 
            this.turnRight()
            this.Dispatch(rest)
        |   [] -> ()
        |   rest -> this.Dispatch(rest)
        
    member this.Move(commands: string) = 
        this.Dispatch(commands |> Seq.toList)
        (x, y, d)
