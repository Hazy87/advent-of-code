namespace DayTwelve.Services;

public class ProcessRunner : IProcessRunner
{
    private readonly IInputService _inputService;
    private readonly IPathFindingService _pathFindingService;

    public ProcessRunner(IInputService inputService, IPathFindingService pathFindingService)
    {
        _inputService = inputService;
        _pathFindingService = pathFindingService;
    }

    public async Task Run()
    {
        var caveConnectionsList = await _inputService.GetLines(); 
        //var caveConnectionsList = new List<CaveConnections>() { new() { PointA = "start", PointB = "A" }, new() { PointA = "start", PointB = "b" }, new() { PointA = "A", PointB = "c" }, new() { PointA = "A", PointB = "b" }, new() { PointA = "b", PointB = "d" }, new() { PointA = "A", PointB = "end" }, new() { PointA = "b", PointB = "end" } };
        var paths = _pathFindingService.FindPaths(caveConnectionsList);
        Console.WriteLine($"done {paths.Count}");
    }
}