using DayFive.Domain;

namespace DayFive.Services;

public class InputService : IInputService
{
    public async Task<List<Vents>> GetCoordinateListAsync()
    {
        var returnList = new List<Vents>();
        var lines = await File.ReadAllLinesAsync("input.txt");
        foreach (var line in lines)
        {
            returnList.Add(AddVent(line, returnList));
        }
        return returnList;
    }

    private static Vents AddVent(string line, List<Vents> returnList)
    {
        var start = line.Split(" -> ")[0];
        var end = line.Split(" -> ")[1];
        return new Vents
        {
            Start = new Coordinate
            {
                X = int.Parse(start.Split(",")[0]),
                Y = int.Parse(start.Split(",")[1])
            },
            Finish = new Coordinate
            {
                X = int.Parse(end.Split(",")[0]),
                Y = int.Parse(end.Split(",")[1])
            }
        };
    }
}