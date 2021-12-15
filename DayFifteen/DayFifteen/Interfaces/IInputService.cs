namespace DayFifteen.Interfaces;

public interface IInputService
{
    Task<Grid> GetLines(bool example = true);
}