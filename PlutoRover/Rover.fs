namespace PlutoRover

type Rover(x0, y0 ,d0) = 
    let mutable x = x0
    let mutable y = y0
    let mutable d = d0
    member this.Move(commands) = 
        y <- y + 1
        (x, y, d)
        
        
