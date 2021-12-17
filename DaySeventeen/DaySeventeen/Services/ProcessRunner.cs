namespace DaySeventeen.Services;

public class ProcessRunner : IProcessRunner
{
    private readonly IInputService _inputService;
    private readonly IProbePlottingService _probePlottingService;

    public ProcessRunner(IInputService inputService, IProbePlottingService probePlottingService)
    {
        _inputService = inputService;
        _probePlottingService = probePlottingService;
    }

    public async Task Run()
    {
        var currentX = 0;
        var currentY = 0;
        var input = _inputService.GetLines();
        var overshotX = false;
        var highestPoint =  0;
        ParallelFor(input, highestPoint);
        Console.WriteLine($"done { highestPoint}");
    }

    private void NoneParallel(Input input, int highestPoint)
    {
        for (int yVelocity = 2000; yVelocity > 0; yVelocity--)
        {
            for (int xVelocity =0; xVelocity > 0; xVelocity--)
            {
                var findHighestPoint = _probePlottingService.HighestPoint(xVelocity, yVelocity, input);
                if (findHighestPoint.HasValue && findHighestPoint.Value > highestPoint)
                    highestPoint = findHighestPoint.Value;

                //break;
            }
        }
    }

    private void ParallelFor(Input input, int highestPoint)
    {
        Parallel.For(0, 2000, new ParallelOptions() { MaxDegreeOfParallelism = 24 }, yVelocity =>
        {
            Parallel.For(0, input.MaxX, new ParallelOptions() { MaxDegreeOfParallelism = 24 }, xVelocity =>
            {
                var findHighestPoint = _probePlottingService.HighestPoint(xVelocity, yVelocity, input);
                if (findHighestPoint.HasValue && findHighestPoint.Value > highestPoint)
                {
                    highestPoint = findHighestPoint.Value;
                    Console.WriteLine(highestPoint);
                }

                //break;
            });
           
        });
    }
}