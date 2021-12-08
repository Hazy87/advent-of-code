using System.ComponentModel;
using DayEight.Domain;
using Microsoft.VisualBasic;

namespace DayEight.Services;

public partial class ProcessRunner : IProcessRunner
{
    private readonly IInputService _inputService;
    private readonly INumberFindingService _numberFindingService;
    private readonly IDecodeService _decodeService;

    public ProcessRunner(IInputService inputService, INumberFindingService numberFindingService, IDecodeService decodeService)
    {
        _inputService = inputService;
        _numberFindingService = numberFindingService;
        _decodeService = decodeService;
    }

    public async Task Run()
    {
        var input = await _inputService.GetInput();
        var counter = 0;
        foreach (var line in input)
        {
            var numbers = FindNumbers(line.SignalPatternsList);
            var decoded = _decodeService.Decode(numbers, line.DigitalOutputsList);
            counter += decoded;
        }

        Console.WriteLine($"Counter is {counter}");
    }
    private Dictionary<string, int> FindNumbers(List<string> patterns)
    {
        var returnDictionary = new Dictionary<string, int>();
        returnDictionary[SortString(patterns.Single(x => x.Length == 2))] = 1;
        returnDictionary[SortString(patterns.Single(x => x.Length == 4))] = 4;
        returnDictionary[SortString(patterns.Single(x => x.Length == 3))] = 7;
        returnDictionary[SortString(patterns.Single(x => x.Length == 7))] = 8;
        var sixNineAndZero = patterns.Where(x => x.Length == 6);
        var twoThreeAndFive = patterns.Where(x => x.Length == 5);
        var (zero, six, nine) = _numberFindingService.SplitSixNineZero(sixNineAndZero.ToList(), returnDictionary.Single(x => x.Value == 1).Key, returnDictionary.Single(x => x.Value == 4).Key, returnDictionary.Single(x => x.Value == 7).Key);
        var (two, three, five) = _numberFindingService.SplitTwoThreeAndFive(twoThreeAndFive.ToList(), returnDictionary.Single(x => x.Value == 1).Key, nine);
        returnDictionary[SortString(zero)] = 0;
        returnDictionary[SortString(six)] = 6;
        returnDictionary[SortString(nine)] = 9;
        returnDictionary[SortString(two)] = 2;
        returnDictionary[SortString(three)] = 3;
        returnDictionary[SortString(five)] = 5;
        return returnDictionary;
    }

    public static string SortString(string toBeSorted)
    {
        var charArray = toBeSorted.ToCharArray();
        Array.Sort(charArray);
        return new string(charArray);
    }
}

