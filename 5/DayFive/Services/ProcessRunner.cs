using DayFive.Domain;
using DayFive.Interfaces;

namespace DayFive.Services;

public class ProcessRunner : IProcessRunner
{
    private readonly IInputService inputService;
    private readonly IGridMarkerService gridMarkerService;
    private readonly ICoordinateService coordinateService;

    public ProcessRunner(IInputService inputService, IGridMarkerService gridMarkerService, ICoordinateService coordinateService)
    {
        this.inputService = inputService;
        this.gridMarkerService = gridMarkerService;
        this.coordinateService = coordinateService;
    }
    public async Task Run()
    {
        var grid = new Grid();
        var vents = await inputService.GetCoordinateListAsync();
        var coordinates = new List<Coordinate>();
        foreach (var vent in vents)
        {
            coordinates.AddRange(coordinateService.GetCoordinateListFromRange(vent.Start, vent.Finish));
        }
        foreach (var coordinate in coordinates)
        {
            gridMarkerService.MarkGrid(grid, coordinate);
        }
        var bigOnes = grid.VentPlacements.Where(x => x.Value > 1).Count();
        Console.WriteLine($"Found {bigOnes} big ones");
    }
}
