namespace DayTen.Interfaces;

public interface ICorruptionFinder
{
    char? FindFirstWrongCharacter(string line);
    string GetAutocompletedString(string line);
    bool IsCorruptLine(string line);
    long GetAutoCompletedScore(string completedLine);
}