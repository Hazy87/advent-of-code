using DayTwelve.Interfaces;

namespace DayTwelve.Services;

public class InputService :IInputService
{
    public async Task<List<CaveConnections>> GetLines()
    {
        var cavePoints = new List<CaveConnections>();
        var readAllLinesAsync = await File.ReadAllLinesAsync("input.txt");
        foreach (var line in readAllLinesAsync)
        {
            var split = line.Split("-");
            if(split[1] == "start")
                cavePoints.Add(new CaveConnections() { PointA = split[1], PointB = split[0] });
            else
                cavePoints.Add(new CaveConnections(){ PointA = split[0], PointB = split[1]});
        }
        return cavePoints;
    }
    
}