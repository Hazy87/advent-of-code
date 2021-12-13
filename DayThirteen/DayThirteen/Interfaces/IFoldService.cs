namespace DayThirteen.Interfaces;

public interface IFoldService
{
    Coordinate GetNewCoordinateAfterFold(Coordinate coordinate, Fold fold);
    IEnumerable<Coordinate> GetNewCoordinatesAfterFold(List<Coordinate> coordinates, Fold fold);
    List<Coordinate> GetNewCoordinatesAfterFolds(List<Coordinate> coordinates, List<Fold> folds);
    void Print(List<Coordinate> foldedCordinates);
}