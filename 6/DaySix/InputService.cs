public class InputService :IInputService
{
    public async Task<IEnumerable<LanternFish>> GetLaternFish()
    {
        var lines = await File.ReadAllLinesAsync("input.txt");
        return lines[0].Split(",").Select(x => new LanternFish { SpawnTimer = int.Parse(x) });
    }
}