using DaySixteen.Services;
using Xunit;

namespace DaySixteen.Tests;

public class HexadecimalConverterServiceTests
{
    public HexadecimalConverterServiceTests()
    {
        new HexadecimalConverterService();
    }
    [Theory]
    [InlineData("D2FE28", "110100101111111000101000")]
    [InlineData("38006F45291200", "00111000000000000110111101000101001010010001001000000000")]
    [InlineData("8A004A801A8002F478", "100010100000000001001010100000000001101010000000000000101111010001111000")]
    public void ConvertHexToBinary_should_Return_Correct(string hexadecimal, string expectedResult)
    {
        var output = HexadecimalConverterService.ConvertHexToBinary(hexadecimal);
        Assert.Equal(expectedResult, output);
    }
}