namespace DayThirteen.Interfaces;

public interface IPrintService
{
    void Print(IEnumerable<(int X, int Y)> foldedCoordinates);
}