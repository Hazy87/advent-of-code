using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DaySixteen.Services;

public class ProcessRunner : IProcessRunner
{
    private readonly IInputService _inputService;
    private readonly IHexadecimalConverterService _hexadecimalConverterService;
    private readonly IPacketParsingService _packetParsingService;

    public ProcessRunner(IInputService inputService, IHexadecimalConverterService hexadecimalConverterService, IPacketParsingService packetParsingService)
    {
        _inputService = inputService;
        _hexadecimalConverterService = hexadecimalConverterService;
        _packetParsingService = packetParsingService;
    }

    public async Task Run()
    {
        var hexa = await _inputService.GetLines();
        var binary = HexadecimalConverterService.ConvertHexToBinary(hexa);
        var packet = new Packet(binary);
        var packetSubPackets = packet.VersionSum;
        if(packetSubPackets!= null)
            Console.WriteLine($"done: {packet.Value}");
    }
}