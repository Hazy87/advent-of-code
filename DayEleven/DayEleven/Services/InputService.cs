namespace DayEleven.Services;

public class InputService :IInputService
{
    public async Task<List<Octopus>> GetLines()
    {
        var octopuses = new List<Octopus>();
        var readAllLinesAsync = await File.ReadAllLinesAsync("input.txt");
        for (int y = 0; y <= readAllLinesAsync.Length -1; y++)
        {
            for (int x = 0; x <= readAllLinesAsync[y].Length -1; x++)
            {
                var octopus = new Octopus
                {
                    Y = int.Parse(y.ToString()),
                    X = int.Parse(x.ToString()),
                    Energy = int.Parse(readAllLinesAsync[y][x].ToString())
                };
                octopuses.Add(octopus);
            }
        }
       
        return octopuses;
    }
    
}