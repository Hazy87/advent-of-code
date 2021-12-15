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

    public void IncreaseGridSize(Grid grid, int size)
    {
        var horizontalDuplicates = new List<Node>();
        var verticalDuplicates = new List<Node>();
        for (var i = 1; i < size; i++)
        {
            var i1 = i;
            horizontalDuplicates.AddRange(grid.Nodes.Select(x =>
            {
                var argRiskFactor = x.RiskFactor + i1 > 9 ? x.RiskFactor + i1 - 9: x.RiskFactor + i1;
                return new Node()
                    {
                        Distance = int.MaxValue, RiskFactor = argRiskFactor,
                        X = x.X + (i * grid.XSize), Y = x.Y, Visited = false
                    };
            }));
        }
        grid.Nodes.AddRange(horizontalDuplicates);

        for (var i = 1; i < size; i++)
        {
            var i1 = i;
            verticalDuplicates.AddRange(grid.Nodes.Select(x =>
            {
                var argRiskFactor = x.RiskFactor + i1 > 9 ? x.RiskFactor + i1 -9: x.RiskFactor + i1;
                return new Node()
                    {
                        Distance = int.MaxValue, RiskFactor = argRiskFactor,
                        Y = x.Y + (i * grid.YSize), X = x.X, Visited = false
                    };
            }));
        }

        grid.XSize *= size;
        grid.YSize *= size;
        grid.Nodes.AddRange(verticalDuplicates);
    }
}