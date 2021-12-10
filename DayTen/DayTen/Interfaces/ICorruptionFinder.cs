namespace DayTen.Interfaces;

public interface ICorruptionFinder
{
    char? FindFirstWrongCharacter(string line);
}