namespace DayThirteen.Services;

public class PrintService : IPrintService
{
    public void Print(IEnumerable<(int X, int Y)> foldedCoordinates)
    {
        for (var y = 0; y <= foldedCoordinates.Max(x => x.Y); y++)
        {
            PrintLine(foldedCoordinates, y, foldedCoordinates.Max(x => x.X));
        }
    }

    public static void PrintLine(IEnumerable<(int X, int Y)> foldedCoordinates, int y, int xMax)
    {
        for (var x = 0; x <= xMax; x++)
        {
            Console.Write(foldedCoordinates.Any(oldedCoordinate => oldedCoordinate.X == x && oldedCoordinate.Y == y) ? "#" : ".");
        }
        Console.Write(Environment.NewLine);
    }

}