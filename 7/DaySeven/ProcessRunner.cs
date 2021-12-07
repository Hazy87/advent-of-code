using System.Collections.Concurrent;

public class ProcessRunner : IProcessRunner
{
    private readonly IInputService _inputService;
    private readonly IFuelCalculatorService _fuelCalculatorService;

    public ProcessRunner(IInputService inputService, IFuelCalculatorService fuelCalculatorService)
    {
        _inputService = inputService;
        _fuelCalculatorService = fuelCalculatorService;
    }

    public async Task Run()
    {
        var postitions = await _inputService.GetPositions();
        var minFuel= _fuelCalculatorService.GetMinimumFuelRequiredFuelRates(postitions.ToArray());
        Console.WriteLine(minFuel);
    }
}