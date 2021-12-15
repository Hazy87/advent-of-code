using System.Runtime.InteropServices;
using System.Threading.Tasks.Dataflow;

namespace DayFifteen.Services;

public class ProcessRunner : IProcessRunner
{
    private readonly IInputService _inputService;
    private readonly IDijkstraService _dijkstraService;

    public ProcessRunner(IInputService inputService, IDijkstraService dijkstraService)
    {
        _inputService = inputService;
        _dijkstraService = dijkstraService;
    }

    public async Task Run()
    {
        var grid = await _inputService.GetLines(false);
        _inputService.IncreaseGridSize(grid, 5);
        var counter = 1;
        var nodesCount = grid.Nodes.Count;
        while (grid.Nodes.Count(x => !x.Visited) != 0)
        {
            var unVisitedNeighbour = grid.Nodes.Where(x => !x.Visited);
            var currentNode = unVisitedNeighbour.OrderBy(x => x.Distance).First();
            var neighbours = _dijkstraService.GetNeighbours(currentNode, unVisitedNeighbour.ToList());
            _dijkstraService.ConsiderNode(currentNode, neighbours);
            Console.WriteLine($"Considering node {counter} of {nodesCount} : {(counter / nodesCount) * 100}");
            counter++;
            if (currentNode.X == grid.XSize - 1 && currentNode.Y == grid.YSize - 1)
                break;
        }
         
        //print(grid.Nodes);
        var destinationNode = grid.Nodes.First(x => x.X == grid.XSize-1 && x.Y == grid.YSize-1);
        Console.WriteLine($"done distance is {destinationNode.Distance}");
    }

    private void print(List<Node> gridNodes)
    {
        foreach (var ygroup in gridNodes.GroupBy(x => x.Y))
        {
            var printable = ygroup.OrderBy(x => x.X).Select(x => x.RiskFactor);
            Console.WriteLine(string.Join("", printable));
        }
    }
}