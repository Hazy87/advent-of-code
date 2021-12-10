using DayTen.Services;
using Xunit;

namespace DayTen.Tests;

public class CorruptionFinderTests
{
    private readonly CorruptionFinder _service;

    public CorruptionFinderTests()
    {
        _service = new CorruptionFinder();
    }

    [Theory]
    [InlineData("{([(<{}[<>[]}>{[]{[(<()>", '}')]
    [InlineData("[[<[([]))<([[{}[[()]]]", ')')]
    [InlineData("[{[{({}]{}}([{[{{{}}([]", ']')]
    [InlineData("[<(<(<(<{}))><([]([]()", ')')]
    [InlineData("<{([([[(<>()){}]>(<<{{", '>')]
    public void CorruptionFinder_Should_Return_Correct_Char(string testString, char expectedResult)
    {
        var result = _service.FindFirstWrongCharacter(testString);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("{([(<{}[<>[]}>{[]{[(<()>", true)]
    [InlineData("[[<[([]))<([[{}[[()]]]",true)]
    [InlineData("[{[{({}]{}}([{[{{{}}([]", true)]
    [InlineData("[<(<(<(<{}))><([]([]()", true)]
    [InlineData("<{([([[(<>()){}]>(<<{{", true)]
    [InlineData("[({(<(())[]>[[{[]{<()<>>", false)]
    [InlineData("[(()[<>])]({[<{<<[]>>(", false)]
    [InlineData("{<[[]]>}<{[{[{[]{()[[[]", false)]
    [InlineData("<{([{{}}[<[[[<>{}]]]>[]]", false)]
    public void IsCorruptShouldReturnCorrectResult(string testString, bool expectedResult)
    {
        var result = _service.IsCorruptLine(testString);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("[({(<(())[]>[[{[]{<()<>>", "}}]])})]") ]
    [InlineData("[(()[<>])]({[<{<<[]>>(", ")}>]})")]
    [InlineData("{<[[]]>}<{[{[{[]{()[[[]", "]]}}]}]}>")]
    [InlineData("<{([{{}}[<[[[<>{}]]]>[]]", "])}>")]
    public void AutCompleteShouldReturnCorrectResult(string testString, string expectedResult)
    {
        var result = _service.GetAutocompletedString(testString);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("}}]])})]", 288957)]
    [InlineData(")}>]})", 5566)]
    [InlineData("}}>}>))))", 1480781)]
    [InlineData("]]}}]}]}>", 995444)]
    [InlineData("])}>", 294)]
    public void AutoCompleteScoreShouldReturnCorrectResult(string testString, int expectedResult)
    {
        var result = _service.GetAutoCompletedScore(testString);
        Assert.Equal(expectedResult, result);
    }
}