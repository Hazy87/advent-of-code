namespace DayThirteen.Services;

public class ProcessRunner : IProcessRunner
{
    private readonly IInputService _inputService;
    private readonly IFoldService _foldService;
    private readonly IPrintService _printService;

    public ProcessRunner(IInputService inputService, IFoldService foldService, IPrintService printService)
    {
        _inputService = inputService;
        _foldService = foldService;
        _printService = printService;
    }
    public async Task Part1()
    {
        var (coordinates, folds) = await _inputService.GetInput();
        var foldedCoordinates = _foldService.GetNewCoordinatesAfterFold(coordinates, folds.FirstOrDefault()).Distinct();
        Console.WriteLine($"Part 1 : Count after 1 fold is {foldedCoordinates.Count()}");
    }
    public async Task Part2()
    {
        var (coordinates, folds) = await _inputService.GetInput();
        var foldedCoordinates = _foldService.GetNewCoordinatesAfterFolds(coordinates, folds).Distinct();

        _printService.Print(foldedCoordinates);
    }
}