using DaySixteen.Services;
using Microsoft.VisualBasic;
using Xunit;

namespace DaySixteen.Tests;

public class PacketParsingServiceTests
{
    private readonly PacketParsingService _service;

    public PacketParsingServiceTests()
    {
        _service = new PacketParsingService();
    }

    [Theory]
    [InlineData("110100101111111000101000", 6)]
    [InlineData("00111000000000000110111101000101001010010001001000000000", 1)]
    public void GetVersion(string binary, int expectedVersion)
    {
        var version = _service.GetVersion(binary);
        Assert.Equal(expectedVersion,version);
    }

    [Theory]
    [InlineData("110100101111111000101000", 4)]
    [InlineData("00111000000000000110111101000101001010010001001000000000", 6)]
    public void GetPacketType(string binary, int expectedVersion)
    {
        var version = _service.GetPacketType(binary);
        Assert.Equal(expectedVersion, version);
    }

    [Theory]
    [InlineData("11101110000000001101010000001100100000100011000001100000", 1)]
    [InlineData("00111000000000000110111101000101001010010001001000000000", 0)]
    public void GetLengthId(string binary, int expectedVersion)
    {
        var version = _service.GetLengthTypeId(binary);
        Assert.Equal(expectedVersion, version);
    }

    [Theory]
    [InlineData("11101110000000001101010000001100100000100011000001100000", 3)]
    public void GetNumberOfSubpackets(string binary, int expectedVersion)
    {
        var version = _service.GetNumberOfSubpackets(binary);
        Assert.Equal(expectedVersion, version);
    }

    [Theory]
    [InlineData("00111000000000000110111101000101001010010001001000000000", 27)]
    public void GetLengthOfSubpackets(string binary, int expectedVersion)
    {
        var version = _service.GetLengthOfSubpackets(binary);
        Assert.Equal(expectedVersion, version);
    }

    [Theory]
    [InlineData("01010000001", 1)]
    [InlineData("10010000010", 2)]
    [InlineData("00110000011", 3)]
    public void GetLiteralValueFromPacket(string binary, int expectedVersion)
    {
        var version = _service.GetLiteralValueFromPacket(binary);
        Assert.Equal(expectedVersion, version);
    }

    [Theory]
    [InlineData("00111000000000000110111101000101001010010001001000000000", 2)]
    [InlineData("11101110000000001101010000001100100000100011000001100000", 3)]
    public void GetSubPackets_Count(string binary, int expectedCount)
    {
        var version = _service.GetSubPackets(binary, _service.GetLengthTypeId(binary));
        Assert.Equal(expectedCount, version.Count);
    }
}