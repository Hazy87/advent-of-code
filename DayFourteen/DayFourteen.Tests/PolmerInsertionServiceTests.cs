using System.Linq;
using DayFourteen.Services;
using Xunit;

namespace DayFourteen.Tests;

public class PolmerInsertionServiceTests
{
    private readonly PolimerInsertionService _service;

    public PolmerInsertionServiceTests()
    {
        _service = new PolimerInsertionService();
    }

    [Theory]
    [InlineData("NNCB", "NN -> C", "NCNCB")]
    [InlineData("NNCB", "CB -> A", "NNCAB")]
    [InlineData("NNCB", "NN -> C,CB -> A", "NCNCAB")]
    [InlineData("NNCB", "NN -> C,CB -> A,NC -> B", "NCNBCAB")]
    public void Insertion_ShouldReturnCorrectString(string polymer, string templates, string result)
    {
        //var templateList = templates.Split(",").Select(x => (x.Split(" -> ")[0], x.Split(" -> ")[0].ToCharArray()[0] + x.Split(" -> ")[1] + x.Split(" -> ")[0].ToCharArray()[1])).ToList();
        var templateList = templates.Split(",").Select(x => (x.Split(" -> ")[0],x.Split(" -> ")[1] )).ToList();
        var output = _service.InsertPolimer(polymer, templateList);
        Assert.Equal(result, output);
    }
}