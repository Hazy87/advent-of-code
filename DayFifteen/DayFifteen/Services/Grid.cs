namespace DayFifteen.Services;

public class Grid
{
    public int YSize { get; set; }
    public int XSize { get; set; }
    public List<Node> Nodes { get; set; } = new();
}