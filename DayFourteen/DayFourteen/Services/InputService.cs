using System.Formats.Asn1;
using DayFourteen.Interfaces;

namespace DayFourteen.Services;

public class InputService :IInputService
{
    public async Task<(string template, List<(string input, string output)> rules)> GetLines(bool example = true)
    {
        var filename = example ? "example.txt" : "input.txt";
        var readAllLinesAsync = await File.ReadAllLinesAsync(filename);
        var templates = readAllLinesAsync.FirstOrDefault();
        var rules = readAllLinesAsync.Skip(2).Select(x => (x.Split(" -> ")[0], x.Split(" -> ")[1])).ToList();
        return (templates, rules);
    }
    
}