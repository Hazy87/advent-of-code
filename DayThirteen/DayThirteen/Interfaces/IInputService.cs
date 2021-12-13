namespace DayThirteen.Interfaces;

public interface IInputService
{
    Task<(List<Coordinate> coordinates, List<Fold> folds)> GetInput();
}