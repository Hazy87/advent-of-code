namespace DayFive.Services;

public class GridMarkerService : IGridMarkerService
{
    public void MarkGrid(Grid grid, Coordinate coordinate)
    {
        if (grid.VentPlacements.ContainsKey((coordinate.X, coordinate.Y)))
            grid.VentPlacements[(coordinate.X, coordinate.Y)] = grid.VentPlacements[(coordinate.X, coordinate.Y)] + 1;
        else
            grid.VentPlacements[(coordinate.X, coordinate.Y)] = 1;
    }
}