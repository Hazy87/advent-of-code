namespace DayThirteen.Interfaces;

public interface IInputService
{
    Task<(IEnumerable<(int X, int Y)> coordinates, IEnumerable<(bool IsYFold, int FoldLine)> folds)> GetInput();
}