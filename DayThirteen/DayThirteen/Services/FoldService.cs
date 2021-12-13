namespace DayThirteen.Services;

public class FoldService : IFoldService
{
    public List<Coordinate> GetNewCoordinatesAfterFolds(List<Coordinate> coordinates, List<Fold> folds)
    {
        var foldedCoordinates = coordinates;
        foreach (var fold in folds)
        {
            foldedCoordinates = GetNewCoordinatesAfterFold(foldedCoordinates, fold).ToList();
            Console.WriteLine($"line {folds.IndexOf(fold)} has {foldedCoordinates.Count} dots");
        }
        return foldedCoordinates;
    }

    public IEnumerable<Coordinate> GetNewCoordinatesAfterFold(List<Coordinate> coordinates, Fold fold)
    {
        return coordinates.Select(coordinate => GetNewCoordinateAfterFold(coordinate, fold));
    }
    public Coordinate GetNewCoordinateAfterFold(Coordinate coordinate, Fold fold)
    {
        return fold.IsYFold switch
        {
            true when coordinate.Y > fold.FoldLine => YFold(coordinate, fold.FoldLine),
            false when coordinate.X > fold.FoldLine => XFold(coordinate, fold.FoldLine),
            _ => coordinate
        };
    }
    public void Print(List<Coordinate> foldedCordinates)
    {
        for (var y = 0; y <= foldedCordinates.Max(x => x.Y); y++)
        {
            PrintLine(foldedCordinates, y, foldedCordinates.Max(x => x.X));
        }
    }

    private static void PrintLine(List<Coordinate> foldedCordinates, int y, int xMax)
    {
        for (var x = 0; x <= xMax; x++)
        {
            Console.Write(foldedCordinates.Any(z => z.X == x && z.Y == y) ? "#" : ".");
        }
        Console.Write(Environment.NewLine);
    }

    private Coordinate YFold(Coordinate coordinate, int foldLine)
    {
        return new Coordinate { X = coordinate.X, Y = foldLine - (coordinate.Y - foldLine) };
    }
    private Coordinate XFold(Coordinate coordinate, int foldLine)
    {
        return new Coordinate { X = foldLine - (coordinate.X - foldLine), Y = coordinate.Y};
    }
}