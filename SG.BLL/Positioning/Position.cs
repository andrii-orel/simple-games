using SG.BLL.MartianRobot;

namespace SG.BLL.Positioning;

public class Position
{
    public Coordinates Coordinates { get; }
    public char Direction { get; set; }

    public Position(int x, int y, char direction)
    {
        Coordinates = new Coordinates(x, y);
        Direction = direction;
    }
}