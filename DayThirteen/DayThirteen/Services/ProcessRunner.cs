namespace DayThirteen.Services;

public class ProcessRunner : IProcessRunner
{
    private readonly IInputService _inputService;
    private readonly IFoldService _foldService;

    public ProcessRunner(IInputService inputService, IFoldService foldService)
    {
        _inputService = inputService;
        _foldService = foldService;
    }

    public async Task Run()
    {
        var (coordinates, folds) = await _inputService.GetInput();
        var foldedCordinates = _foldService.GetNewCoordinatesAfterFolds(coordinates, folds);
        _foldService.Print(foldedCordinates);
    }
}