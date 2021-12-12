namespace DayEleven.Services;

public class ProcessRunner : IProcessRunner
{
    private readonly IInputService _inputService;
    private readonly IFlashService _flashService;

    public ProcessRunner(IInputService inputService, IFlashService flashService)
    {
        _inputService = inputService;
        _flashService = flashService;
    }

    public async Task Run()
    {
        var octopuses = await _inputService.GetLines();
        int steps = 10;
        int flashes = 0;
        PrintBoard(octopuses);
        for (int i = 1; i <= 1000; i++)
        {
            _flashService.IncrementAll(octopuses);
            flashes += _flashService.Flash(octopuses);
            //PrintBoard(octopuses);
            if(octopuses.All(x => x.Flashed))
                Console.WriteLine($"All flashed at {i}");
        }

        Console.WriteLine($"done {flashes}");
    }

    private static void PrintBoard(List<Octopus> octopuses)
    {
        foreach (var octopusGroups in octopuses.GroupBy(x => x.Y))
        {
            Console.WriteLine(string.Join("", octopusGroups.Select(x => x.Energy)));

        }
        Console.WriteLine($"");
        Console.WriteLine($"");

    }
}