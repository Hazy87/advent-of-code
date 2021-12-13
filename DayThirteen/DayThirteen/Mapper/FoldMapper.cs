namespace DayThirteen.Mapper;

public class FoldMapper
{
    public static Fold Map(string arg)
    {
        var fold = arg.Replace("fold along", "");
        var foldLine = int.Parse(fold.Split("=")[1]);
        return new Fold
        {
            IsYFold = fold.Trim().StartsWith("y="),
            FoldLine = foldLine
        };
    }
}