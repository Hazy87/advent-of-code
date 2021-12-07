public class InputService :IInputService
{
    public async Task<IEnumerable<int>> GetPositions()
    {
        var lines = await File.ReadAllLinesAsync("input.txt");
        return lines[0].Split(",").Select(x => int.Parse(x));
    }
}