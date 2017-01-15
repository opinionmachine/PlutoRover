namespace PlutoRoverTests
open NUnit.Framework
open PlutoRover

[<TestFixture>]
type RoverTests() = 
    
    [<Test>]
    member this.Can_move_forward() = 
        let r = Rover(0,0,'N')
        let pos = r.Move("F")
        let x,y,d = pos
        Assert.That(x, Is.EqualTo(0));
        Assert.That(y, Is.EqualTo(1));
        Assert.That(d, Is.EqualTo('N'));
    
    [<Test>]    
    member this.Can_move_backward() = 
        let r = Rover(1,1,'N')
        let pos = r.Move("B")
        let x,y,d = pos
        Assert.That(x, Is.EqualTo(1));
        Assert.That(y, Is.EqualTo(0));
        Assert.That(d, Is.EqualTo('N'));

    [<TestCase('N', 'E')>]    
    [<TestCase('E', 'S')>]    
    member this.When_I_turn_right_from_D1_I_point_D2(d1 : char, d2: char) = 
        let r = Rover(0,0, d1)
        let pos = r.Move("R")
        let x,y,d = pos
        Assert.That(x, Is.EqualTo(0));
        Assert.That(y, Is.EqualTo(0));
        Assert.That(d, Is.EqualTo(d2));
