namespace DayThirteen.Mapper;

public class CoordinateMapper
{
    public static (int X, int Y) Map(string arg)
    {
        var strings = arg.Split(",");
        return (
            int.Parse(strings[0]),int.Parse(strings[1])
        );
    }
}