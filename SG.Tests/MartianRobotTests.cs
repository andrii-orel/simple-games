using SG.BLL.MartianRobot;

namespace SG.Tests;

public class MartianRobotTests
{
    [Fact]
    public void Should_Initialize_Rover_Correctly()
    {
        // Arrange
        var rover = new MartianRobot(5,7, 1, 2, 'N');

        // Assert
        Assert.Equal(5, rover.GetMartianBoard.GetMaxWidth);
        Assert.Equal(7, rover.GetMartianBoard.GetMaxHeight);
        Assert.Equal(1, rover.GetCurrentPosition.Coordinates.X);
        Assert.Equal(2, rover.GetCurrentPosition.Coordinates.Y);
        Assert.Equal('N', rover.GetCurrentPosition.Direction);
    }

    [Fact]
    public void Should_Turn_Left_From_North_To_West1()
    {
        // Arrange
        var rover = new MartianRobot(5,5, 0, 0, 'N');
        
        // Act
        rover.ExecuteCommand("L");

        // Assert
        Assert.Equal('W', rover.GetCurrentPosition.Direction);
    }
    
    [Fact]
    public void Should_Turn_Left_From_North_To_West2()
    {
        // Arrange
        var rover = new MartianRobot(5,5, 0, 0, 'N');
        
        // Act
        rover.TurnLeft();

        // Assert
        Assert.Equal('W', rover.GetCurrentPosition.Direction);
    }

    [Fact]
    public void Should_Turn_Right_From_North_To_East()
    {
        // Arrange
        var rover = new MartianRobot(5,5, 0, 0, 'N');
        rover.ExecuteCommand("R");

        // Assert
        Assert.Equal('E', rover.GetCurrentPosition.Direction);
    }

    [Fact]
    public void Should_Move_Forward_North()
    {
        // Arrange
        var rover = new MartianRobot(5,5, 0, 0, 'N');
        rover.ExecuteCommand("M");

        // Assert
        Assert.Equal(1, rover.GetCurrentPosition.Coordinates.Y);
    }

    [Fact]
    public void Should_Follow_Complex_Command_Sequence()
    {
        // Arrange
        var rover = new MartianRobot(5,5, 0, 0, 'N');
        rover.ExecuteCommand("MRMMLMMRMMLM");

        // Assert
        Assert.Equal(4, rover.GetCurrentPosition.Coordinates.X);
        Assert.Equal(4, rover.GetCurrentPosition.Coordinates.Y);
        Assert.Equal('N', rover.GetCurrentPosition.Direction);
    }

    [Fact]
    public void Should_Throw_Exception_If_Moves_Out_Of_Bounds()
    {
        // Arrange
        var rover = new MartianRobot(5,5, 0, 0, 'S');

        // Assert
        Assert.Throws<InvalidOperationException>(() => rover.ExecuteCommand("M"));
    }
    
    [Fact]
    public void Should_Throw_Exception_If_Board_Is_Not_Valid()
    {
        // Arrange

        // Assert
        Assert.Throws<ArgumentException>(() => new MartianRobot(5,51, 0, 0, 'S'));
    }
    
    [Fact]
    public void Should_Throw_Exception_If_Command_Out_Of_Range()
    {
        // Arrange
        var rover = new MartianRobot(5,5, 0, 0, 'N');

        // Assert
        Assert.Throws<ArgumentException>(() => rover.ExecuteCommand("MRMMLMMRMMLMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM"));
    }
}