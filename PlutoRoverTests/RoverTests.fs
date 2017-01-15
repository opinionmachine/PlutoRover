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
        
