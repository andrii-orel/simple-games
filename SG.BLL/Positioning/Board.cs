namespace SG.BLL.Positioning;

public class Board
{
    private const int MaxBoardSize = 50;
    private int WidthX { get; }
    private int HeightY { get; }

    public int GetMaxWidth => WidthX;
    public int GetMaxHeight => HeightY;

    public Board(int width, int height)
    {
        if (width < 1 || width > MaxBoardSize || height < 1 || height > MaxBoardSize)
        {
            throw new ArgumentException($"Board size must be between 1 and {MaxBoardSize}");
        }
        
        WidthX = width;
        HeightY = height;
    }
}