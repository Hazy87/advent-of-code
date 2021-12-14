namespace DayFourteen.Services;

public class ProcessRunner : IProcessRunner
{
    private readonly IInputService _inputService;
    private readonly IPolimerInsertionService _insertionService;

    public ProcessRunner(IInputService inputService, IPolimerInsertionService insertionService)
    {
        _inputService = inputService;
        _insertionService = insertionService;
    }

    public async Task Run()
    {
        var (template, rules) = await _inputService.GetLines(false);
        //part 1 
        for (int i = 0; i < 10; i++)
        {
            template = _insertionService.InsertPolimer(template, rules);
        }

        var groupBy = template.ToCharArray().GroupBy(x => x);
        var mostCommon = groupBy.Max(x => x.Count());
        var leastCommon = groupBy.Min(x => x.Count());
        var output = mostCommon - leastCommon;
        //var output = _insertionService.InsertPolimer(template, rules);
        //Console.WriteLine($"done {output}");
    }
}