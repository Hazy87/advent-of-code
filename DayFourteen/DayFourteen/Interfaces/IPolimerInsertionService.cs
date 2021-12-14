namespace DayFourteen.Interfaces;

public interface IPolimerInsertionService
{
    string InsertPolimer(string template, List<(string input, string output)> rules);
}