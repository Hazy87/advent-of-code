using System.Collections;

namespace DayFourteen.Interfaces;

public interface IInputService
{
    Task<(string template, Hashtable rules)> GetLines(bool example = true);
}