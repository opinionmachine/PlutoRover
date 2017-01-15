namespace PlutoRoverTests
open NUnit.Framework
open PlutoRover

[<TestFixture>]
type RoverTests() = 
    
    [<Test>]
    
    [<TestCase(0, 0, 'N', "F", 0, 1)>]    
    [<TestCase(0, 0, 'E', "F", 1, 0)>]    
    [<TestCase(1, 1, 'W', "F", 0, 1)>]    
    [<TestCase(1, 1, 'S', "F", 1, 0)>]    
    [<TestCase(1, 1, 'N', "B", 1, 0)>]    
    [<TestCase(1, 1, 'E', "B", 0, 1)>]    
    [<TestCase(0, 0, 'W', "B", 1, 0)>]    
    [<TestCase(0, 0, 'S', "B", 0, 1)>]    
    member this.Can_move_in_specified_direction(x0, y0, d0, cmd, x1, y1) = 
        let r = Rover(x0, y0, d0)
        let pos = r.Move(cmd)
        let x,y,d = pos
        Assert.That(x, Is.EqualTo(x1));
        Assert.That(y, Is.EqualTo(y1));
        Assert.That(d, Is.EqualTo(d0));

    [<TestCase("R",'N', 'E')>]    
    [<TestCase("R",'E', 'S')>]    
    [<TestCase("R",'S', 'W')>]    
    [<TestCase("R",'W', 'N')>]    
    [<TestCase("L",'N', 'W')>]    
    [<TestCase("L",'W', 'S')>]    
    [<TestCase("L",'S', 'E')>]    
    [<TestCase("L",'E', 'N')>]    
    member this.When_I_turn_direction_C_from_D1_I_point_D2(cmd: string, d1 : char, d2: char) = 
        let r = Rover(0,0, d1)
        let pos = r.Move(cmd)
        let x,y,d = pos
        Assert.That(x, Is.EqualTo(0))
        Assert.That(y, Is.EqualTo(0))
        Assert.That(d, Is.EqualTo(d2))

    [<TestCase(0, 0, 'N', "FRF", 1, 1, 'E')>]
    [<TestCase(0, 0, 'N', "FRFLB", 1, 0, 'N')>]
    [<TestCase(1, 1, 'W', "FRFLB", 1, 2, 'W')>]
    member this.Can_execute_compound_instructions(x0, y0, d0, cmd, x1, y1, d1) =
        let r = Rover(x0, y0, d0)
        let pos = r.Move(cmd)
        let x,y,d = pos
        Assert.That(x, Is.EqualTo(x1))
        Assert.That(y, Is.EqualTo(y1))
        Assert.That(d, Is.EqualTo(d1))

    [<Test>]
    member this.Coordinate_system_wraps_at_edges() =
        let r = Rover(0, 0, 'N', 3, 3, [])
        let pos = r.Move("BRB")
        let x,y,d = pos
        Assert.That(x, Is.EqualTo(3))
        Assert.That(y, Is.EqualTo(3))
        Assert.That(d, Is.EqualTo('E'))

    [<Test>]
    member this.Rover_detects_obstacles() =
        let r = Rover(0, 0, 'N', 3, 3, [(1, 1)])
        let m = fun() -> r.Move("FRF") |> ignore
        Assert.That(m, Throws.TypeOf<ObstacleException>())
        
