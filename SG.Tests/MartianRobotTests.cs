using SG.BLL.MartianRobot;

namespace SG.Tests;

public class MartianRobotTests
{
    [Fact]
    public void Should_Initialize_Robot_Correctly()
    {
        // Arrange
        var robot = new MartianRobot(5,7, 1, 2, 'N');

        // Assert
        Assert.Equal(5, robot.GetMartianBoard.GetMaxWidth);
        Assert.Equal(7, robot.GetMartianBoard.GetMaxHeight);
        Assert.Equal(1, robot.GetCurrentPosition.Coordinates.X);
        Assert.Equal(2, robot.GetCurrentPosition.Coordinates.Y);
        Assert.Equal('N', robot.GetCurrentPosition.Direction);
    }

    [Fact]
    public void Should_Turn_Left_From_North_To_West1()
    {
        // Arrange
        var robot = new MartianRobot(5,5, 0, 0, 'N');
        
        // Act
        robot.ExecuteCommand("L");

        // Assert
        Assert.Equal('W', robot.GetCurrentPosition.Direction);
    }
    
    [Fact]
    public void Should_Turn_Left_From_North_To_West2()
    {
        // Arrange
        var robot = new MartianRobot(5,5, 0, 0, 'N');
        
        // Act
        robot.TurnLeft();

        // Assert
        Assert.Equal('W', robot.GetCurrentPosition.Direction);
    }

    [Fact]
    public void Should_Turn_Right_From_North_To_East()
    {
        // Arrange
        var robot = new MartianRobot(5,5, 0, 0, 'N');
        robot.ExecuteCommand("R");

        // Assert
        Assert.Equal('E', robot.GetCurrentPosition.Direction);
    }

    [Fact]
    public void Should_Move_Forward_North()
    {
        // Arrange
        var robot = new MartianRobot(5,5, 0, 0, 'N');
        robot.ExecuteCommand("M");

        // Assert
        Assert.Equal(1, robot.GetCurrentPosition.Coordinates.Y);
    }

    [Fact]
    public void Should_Follow_Complex_Command_Sequence()
    {
        // Arrange
        var robot = new MartianRobot(5,5, 0, 0, 'N');
        
        // Act
        robot.ExecuteCommand("MRMMLMMRMMLM");

        // Assert
        Assert.Equal(4, robot.GetCurrentPosition.Coordinates.X);
        Assert.Equal(4, robot.GetCurrentPosition.Coordinates.Y);
        Assert.Equal('N', robot.GetCurrentPosition.Direction);
    }

    [Fact]
    public void Should_Lost_If_Moves_Out_Of_Bounds()
    {
        // Arrange
        var robot = new MartianRobot(5,5, 0, 0, 'S');
        
        // Act
        robot.ExecuteCommand("M");
        
        // Assert
        Assert.True(robot.GetCurrentPosition.IsLost);
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
        var robot = new MartianRobot(5,5, 0, 0, 'N');

        // Assert
        Assert.Throws<ArgumentException>(() => robot.ExecuteCommand("MRMMLMMRMMLMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM"));
    }
}