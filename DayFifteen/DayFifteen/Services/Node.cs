namespace DayFifteen.Services;

public class Node
{
    public int X { get; set; }
    public int Y { get; set; }
    public int RiskFactor { get; set; }

    public int Distance { get; set; }
    public bool Visited { get; set; }
}