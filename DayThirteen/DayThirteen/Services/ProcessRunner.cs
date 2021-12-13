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

    public async Task Run()
    {
        var (coordinates, folds) = await _inputService.GetInput();
        var foldedCordinates = _foldService.GetNewCoordinatesAfterFolds(coordinates, folds);
        _printService.Print(foldedCordinates);
    }
}