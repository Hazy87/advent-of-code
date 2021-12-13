namespace DayThirteen.Services;

public class FoldService : IFoldService
{
    public List<Coordinate> GetNewCoordinatesAfterFolds(List<Coordinate> coordinates, List<Fold> folds)
    {
        //Print(coordinates);

        var foldedCordinates = coordinates;
        foreach (var fold in folds)
        {
            foldedCordinates = GetNewCoordinatesAfterFold(foldedCordinates, fold);
            //Print(foldedCordinates);
            Console.WriteLine($"line {folds.IndexOf(fold)} has {foldedCordinates.Count} dots");
        }
        return foldedCordinates.DistinctBy(x => (x.X, x.Y)).ToList().OrderBy(x => x.Y).OrderBy(x => x.X).ToList();
    }

    public void Print(List<Coordinate> foldedCordinates)
    {
        var xCordinates = foldedCordinates.Select(x => x.X).OrderBy(x => x);
        var xMax = xCordinates.Any() ? xCordinates.Max() : 0;

        var yCordinates = foldedCordinates.Select(x => x.Y).OrderBy(x => x);
        for (int y = 0; y <= yCordinates.Max(); y++)
        {
            xCordinates = foldedCordinates.Where(x => x.Y == y).Select(x => x.X).OrderBy(x => x);
            for (int x = 0; x <= xMax; x++)
            {
                if(foldedCordinates.Any(z => z.X == x && z.Y == y))
                    Console.Write("#");
                else
                    Console.Write(".");
            }
            Console.Write(Environment.NewLine);
        }
        Console.WriteLine();
    }

    public List<Coordinate> GetNewCoordinatesAfterFold(List<Coordinate> coordinates, Fold fold)
    {
        var foldedCordinates = new List<Coordinate>();
        foreach (var coordinate in coordinates) 
        {
            foldedCordinates.Add(GetNewCoordinateAfterFold(coordinate, fold));
        }

        return foldedCordinates.DistinctBy(x => (x.X, x.Y)).ToList();
    }
    public Coordinate GetNewCoordinateAfterFold(Coordinate coordinate, Fold fold)
    {
        if (fold.IsYFold && coordinate.Y > fold.FoldLine)
            return YFold(coordinate, fold.FoldLine);
        if (coordinate.X > fold.FoldLine && !fold.IsYFold)
            return XFold(coordinate, fold.FoldLine);
        return coordinate;
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