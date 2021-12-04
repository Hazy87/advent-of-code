namespace _4;

public class BoardCheckingService : IBoardCheckingService
{
    public void MarkBoard(string number, Board board)
    {
        foreach (var line in board.PossibleLines)
        {
            if(line.Contains(number))
                line.Remove(number);
        }
    }

    public bool CheckBoard(Board board)
    {
        if (board.PossibleLines.Any(x => x.Count == 0)) return true;
        return false;
    }

    public int CountPoints(Board board, int number)
    {
        return board.PossibleLines.Take(5).SelectMany(x => x).Select(x => int.Parse(x)).Sum() * number;
    }
}
