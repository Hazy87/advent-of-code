using DayTen.Interfaces;

namespace DayTen.Services;

public class InputService :IInputService
{
    public async Task<string[]> GetLines()
    {
        return await File.ReadAllLinesAsync("input.txt");
    }
    
}