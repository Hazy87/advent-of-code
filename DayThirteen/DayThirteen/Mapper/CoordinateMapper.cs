namespace DayThirteen.Mapper;

public class CoordinateMapper
{
    public static Coordinate Map(string arg)
    {
        var strings = arg.Split(",");
        return new()
        {
            X = int.Parse(strings[0]),
            Y = int.Parse(strings[1])
        };
    }
}