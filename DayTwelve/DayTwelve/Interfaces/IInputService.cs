namespace DayTwelve.Interfaces;

public interface IInputService
{
    Task<List<CaveConnections>> GetLines();
}