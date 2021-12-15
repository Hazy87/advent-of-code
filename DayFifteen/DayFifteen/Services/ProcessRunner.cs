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
        while (grid.Nodes.Where(x => !x.Visited).Count() != 0)
        {
            var unVisitedNeighbour = grid.Nodes.Where(x => !x.Visited);
            var currentNode = unVisitedNeighbour.OrderBy(x => x.Distance).First();
            var neighhbours = _dijkstraService.GetNeighbours(currentNode, unVisitedNeighbour.ToList());
            _dijkstraService.ConsiderNode(currentNode, neighhbours);
        }

        var destinationNode = grid.Nodes.First(x => x.X == grid.XSize-1 && x.Y == grid.YSize-1);
        Console.WriteLine($"done distance is {destinationNode.Distance}");
    }
}