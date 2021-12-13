namespace DayThirteen.Mapper;

public class FoldMapper
{
    public static (bool IsYFold, int  FoldLine) Map(string arg)
    {
        var fold = arg.Replace("fold along", "");
        var foldLine = int.Parse(fold.Split("=")[1]);
        return (fold.Trim().StartsWith("y="),foldLine);
    }
}