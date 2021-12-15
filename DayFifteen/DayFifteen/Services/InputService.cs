using System.Collections;
using System.Security.Cryptography;
using DayFifteen.Interfaces;

namespace DayFifteen.Services;


public class InputService : IInputService
{
    public async Task<Grid> GetLines(bool example = true)
    {
        var filename = example ? "example.txt" : "input.txt";
        var readAllLinesAsync = await File.ReadAllLinesAsync(filename);
        var grid = new Grid();
        grid.YSize = readAllLinesAsync.Length;
        grid.XSize = readAllLinesAsync[0].Length;
        for (int y = 0; y < grid.YSize; y++)
        {
            for (int x = 0; x < grid.XSize; x++)
            {
                var maxValue = x == 0 && y == 0 ? 0 : int.MaxValue;
                grid.Nodes.Add(new Node
                {
                    Distance = maxValue, RiskFactor = int.Parse(readAllLinesAsync[y][x].ToString()), X = x, Y = y
                });
            }
            
        }

        return grid;
    }
    
}

public class Grid
{
    public int YSize { get; set; }
    public int XSize { get; set; }
    public List<Node> Nodes { get; set; } = new();
}

public class Node
{
    public int X { get; set; }
    public int Y { get; set; }
    public int RiskFactor { get; set; }

    public int Distance { get; set; }
    public bool Visited { get; set; }
}