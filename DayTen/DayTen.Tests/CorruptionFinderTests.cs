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
}