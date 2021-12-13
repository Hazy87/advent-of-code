namespace DayThirteen.Services;

public class PrintService : IPrintService
{
    public void Print(IEnumerable<(int X, int Y)> foldedCordinates)
    {
        for (var y = 0; y <= foldedCordinates.Max(x => x.Y); y++)
        {
            PrintLine(foldedCordinates, y, foldedCordinates.Max(x => x.X));
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