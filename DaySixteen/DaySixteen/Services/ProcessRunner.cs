namespace DaySixteen.Services;

public class ProcessRunner : IProcessRunner
{
    private readonly IInputService _inputService;

    public ProcessRunner(IInputService inputService)
    {
        _inputService = inputService;
    }

    public async Task Run()
    {
        var hexa = await _inputService.GetLines();
        var binary = HexadecimalConverterService.ConvertHexToBinary(hexa);
        var packet = new Packet(binary);
        Console.WriteLine($"done: versionsum : {packet.VersionSum} , Value : {packet.Value}");
    }
}