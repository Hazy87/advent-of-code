using DayEight.Domain;

namespace DayEight.Interfaces;

public interface IInputService
{
    Task<IEnumerable<Input>> GetInput();
}