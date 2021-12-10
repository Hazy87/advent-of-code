namespace DayTen.Services;

public class ProcessRunner : IProcessRunner
{
    private readonly IInputService _inputService;
    private readonly ICorruptionFinder _corruptionFinder;

    public ProcessRunner(IInputService inputService, ICorruptionFinder corruptionFinder)
    {
        _inputService = inputService;
        _corruptionFinder = corruptionFinder;
    }

    public async Task Run()
    {
        var lines =  await _inputService.GetLines();
        var counter = 0;
        var linecounter = 0;
        foreach (var line in lines)
        {
            linecounter++;
            Console.WriteLine($"line {linecounter}");
            var corruptedChar  = _corruptionFinder.FindFirstWrongCharacter(line);
            if(corruptedChar != null)
                counter += charToCorruptionValue(corruptedChar.Value);
        }
        Console.WriteLine($"done {counter}");
    }

    private int charToCorruptionValue(char corruptedChar)
    {
        switch (corruptedChar)
        {
            case ')':
                return 3;
            case ']':
                return 57;
            case '}':
                return 1197;
            case '>':
                return 25137;
            default:
                throw new Exception("I shouldnt get here");
        }
    }
}