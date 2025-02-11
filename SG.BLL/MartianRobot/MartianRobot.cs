using SG.BLL.Contracts;
using SG.BLL.Positioning;

namespace SG.BLL.MartianRobot;

public class MartianRobot : MartianRobotBase, IMartianRobot, IPlayable
{
    private Board MartianBoard { get; }
    private Position CurrentPosition { get; }
    
    public Board GetMartianBoard => MartianBoard;
    public Position GetCurrentPosition => CurrentPosition;
    
    public MartianRobot(int width, int height, int x, int y, char direction)
    {
        CurrentPosition = new Position(x, y, direction);
        MartianBoard = new Board(width, height);
    }

    public void ExecuteCommand(string commands)
    {
        if(string.IsNullOrWhiteSpace(commands) || commands.Length > CommandMaxLength)
            throw new ArgumentException($"The command must be between 1 and {CommandMaxLength} characters.");

        foreach (var command in commands)
        {
            switch (command)
            {
                case CommandL:
                    TurnLeft();
                    break;
                case CommandR:
                    TurnRight();
                    break;
                case CommandM:
                    Move();
                    break;
                default:
                    throw new InvalidOperationException($"Invalid command: {command}");
            }
        }
    }

    public void TurnLeft()
    {
        CurrentPosition.Direction = CurrentPosition.Direction switch
        {
            DirectionN => DirectionW,
            DirectionW => DirectionS,
            DirectionS => DirectionE,
            DirectionE => DirectionN,
            _ => throw new InvalidOperationException("Invalid direction")
        };
    }

    public void TurnRight()
    {
        CurrentPosition.Direction = CurrentPosition.Direction switch
        {
            DirectionN => DirectionE,
            DirectionE => DirectionS,
            DirectionS => DirectionW,
            DirectionW => DirectionN,
            _ => throw new InvalidOperationException("Invalid direction")
        };
    }

    public void Move()
    {
        int newX = CurrentPosition.Coordinates.X;
        int newY = CurrentPosition.Coordinates.Y;

        switch (CurrentPosition.Direction)
        {
            case DirectionN:
                newY++;
                break;
            case DirectionE:
                newX++;
                break;
            case DirectionS:
                newY--;
                break;
            case DirectionW:
                newX--;
                break;
        }

        if (newX < 0 || newX >= MartianBoard.GetMaxWidth || newY < 0 || newY >= MartianBoard.GetMaxHeight)
        {
            throw new InvalidOperationException("Rover is moving out of bounds!");
        }

        CurrentPosition.Coordinates.X = newX;
        CurrentPosition.Coordinates.Y = newY;
    }
    
    public void Play()
    {
        try
        {
            Console.WriteLine("Enter plateau size (width height): ");
            var plateauSize = Console.ReadLine()?.Split(' ');
            int.TryParse(plateauSize[0], out var width);
            int.TryParse(plateauSize[1], out var height);

            Console.WriteLine("Enter rover position and direction (x y direction): ");
            var roverPosition = Console.ReadLine()?.Split(' ');
            int.TryParse(roverPosition[0], out var x);
            int.TryParse(roverPosition[1], out var y);
            char direction = char.TryParse(roverPosition[2], out var d) 
                ? d 
                : throw new InvalidOperationException($"Invalid command: {roverPosition[2]}");
            
            var martianRobot = new MartianRobot(width, height, x, y, direction);

            Console.WriteLine("Enter movement commands (e.g., MRMMLMMRMMLM): ");
            string commands = Console.ReadLine();

            martianRobot.ExecuteCommand(commands);
            
            Console.WriteLine($"{martianRobot.GetCurrentPosition.Coordinates.X} {martianRobot.GetCurrentPosition.Coordinates.Y} {martianRobot.GetCurrentPosition.Direction}");
            Console.WriteLine($"Final position: X = {martianRobot.GetCurrentPosition.Coordinates.X} Y = {martianRobot.GetCurrentPosition.Coordinates.Y} Direction = {martianRobot.GetCurrentPosition.Direction}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}