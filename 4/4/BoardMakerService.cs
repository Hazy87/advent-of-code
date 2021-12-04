namespace _4;

public class BoardMakerService : IBoardMakerService
{
    public Board Make(string[] lines)
    {
        var horiztonalLines = lines.Select(x => x.Replace("  ", " ")).Select(x => x.Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).ToList()).ToList();
        var boardSize = horiztonalLines.FirstOrDefault().Count;
        var verticalLines = new List<string>();
        for (int i = 0; i <= boardSize-1; i++)
        {
            var line = horiztonalLines.Take(5).Select(x => x[i].ToString()).ToList();
            horiztonalLines.Add(line);
        }
        return new Board { PossibleLines = horiztonalLines.ToList()};
    }
}