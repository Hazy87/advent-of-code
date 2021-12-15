namespace DayFifteen.Interfaces;

public interface IInputService
{
    Task<Grid> GetLines(bool example = true);
    void IncreaseGridSize(Grid grid, int size);
}