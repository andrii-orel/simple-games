namespace SG.BLL.Contracts;

public interface IMartianRobot
{
    void ExecuteCommand(string commands);
    void TurnLeft();
    void TurnRight();
    void Move();
}