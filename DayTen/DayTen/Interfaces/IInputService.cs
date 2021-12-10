namespace DayTen.Interfaces;

public interface IInputService
{
    Task<string[]> GetLines();
}