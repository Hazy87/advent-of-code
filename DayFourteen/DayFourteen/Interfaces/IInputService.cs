namespace DayFourteen.Interfaces;

public interface IInputService
{
    Task<(string template, List<(string input, string output)> rules)> GetLines(bool example = true);
}