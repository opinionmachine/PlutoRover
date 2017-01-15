namespace PlutoRover

type Rover(x0, y0 ,d0, xmax0, ymax0, obstacles0) = 
    let mutable x = x0
    let mutable y :int = y0
    let mutable d = d0
    let xmax :int = xmax0
    let ymax :int = ymax0
    let obstacles = obstacles0
    new(x0, y0, d0) =
        Rover(x0, y0, d0, 100, 100, [])
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
        let mutable ynext = y
        let mutable xnext = x
        match d with 
        |   'N' -> ynext <- y + step
        |   'E' -> xnext <- x + step
        |   'W' -> xnext <- x - step
        |   'S' -> ynext <- y - step
        |   _   -> ()
        if ynext < 0 then ynext <- ymax
        elif xnext < 0 then xnext <- xmax
        if List.contains (xnext, ynext) obstacles then raise(ObstacleException(xnext, ynext))
        y <- ynext
        x <- xnext

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

    member this.Pos() = 
        (x, y, d)
