namespace DayEleven.Interfaces;

public interface IInputService
{
    Task<List<Octopus>> GetLines();
}