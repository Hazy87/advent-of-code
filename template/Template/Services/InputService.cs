using Template.Interfaces;

namespace Template.Services;

public class InputService :IInputService
{
    public async Task<string[]> GetLines()
    {
        return await File.ReadAllLinesAsync("input.txt");
    }
    
}