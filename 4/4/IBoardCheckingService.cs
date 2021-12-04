namespace _4;

public interface IBoardCheckingService
{
    bool CheckBoard(Board board);
    int CountPoints(Board board, int number);
    void MarkBoard(string number, Board board);
}
