namespace DayThirteen.Interfaces;

public interface IFoldService
{
    IEnumerable<(int X, int Y)> GetNewCoordinatesAfterFold(IEnumerable<(int X, int Y)> coordinates,
        (bool IsYFold, int FoldLine) fold);
    IEnumerable<(int X, int Y)> GetNewCoordinatesAfterFolds(IEnumerable<(int X, int Y)> coordinates,
        IEnumerable<(bool IsYFold, int FoldLine)> folds);
    (int X, int Y) GetNewCoordinateAfterFold((int X, int Y) coordinate, (bool IsYFold, int FoldLine) fold);
}