namespace DayThirteen.Services;

public class FoldService : IFoldService
{
    public IEnumerable<(int X, int Y)> GetNewCoordinatesAfterFolds(IEnumerable<(int X, int Y)> coordinates,
        IEnumerable<(bool IsYFold, int FoldLine)> folds)
    {
        var foldedCoordinates = coordinates;
        foreach (var fold in folds)
        {
            foldedCoordinates = GetNewCoordinatesAfterFold(foldedCoordinates, fold).ToList();
        }
        return foldedCoordinates;
    }
    
    public IEnumerable<(int X, int Y)> GetNewCoordinatesAfterFold(IEnumerable<(int X, int Y)> coordinates,
        (bool IsYFold, int FoldLine) fold)
    {
        return coordinates.Select(coordinate => GetNewCoordinateAfterFold(coordinate, fold)).Distinct();
    }
    public (int X, int Y) GetNewCoordinateAfterFold((int X, int Y) coordinate, (bool IsYFold, int FoldLine) fold)
    {
        return fold.IsYFold switch
        {
            true when coordinate.Y > fold.FoldLine => YFold(coordinate, fold.FoldLine),
            false when coordinate.X > fold.FoldLine => XFold(coordinate, fold.FoldLine),
            _ => coordinate
        };
    }
    
    private (int X, int Y) YFold((int X, int Y) coordinate, int foldLine)
    {
        return (coordinate.X, GetFoldedCoordinate(coordinate.Y,foldLine));
    }
    private (int X, int Y) XFold((int X, int Y) coordinate, int foldLine)
    {
        return (GetFoldedCoordinate(coordinate.X, foldLine), coordinate.Y);
    }

    private static int GetFoldedCoordinate(int coordinateToFold, int foldLine)
    {
        return foldLine - (coordinateToFold - foldLine);
    }
}