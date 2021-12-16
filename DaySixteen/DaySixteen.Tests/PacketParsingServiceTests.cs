using System.Collections.Generic;
using DaySixteen.Services;
using Microsoft.VisualBasic;
using Xunit;

namespace DaySixteen.Tests;

public class PacketParsingServiceTests
{

    public PacketParsingServiceTests()
    {
    }

    [Theory]
    [InlineData("110100101111111000101000", 6)]
    [InlineData("00111000000000000110111101000101001010010001001000000000", 1)]
    public void GetVersion(string binary, int expectedVersion)
    {
        var version = PacketParsingService.GetVersion(binary);
        Assert.Equal(expectedVersion,version);
    }

    [Theory]
    [InlineData("110100101111111000101000", 4)]
    [InlineData("00111000000000000110111101000101001010010001001000000000", 6)]
    public void GetPacketType(string binary, int expectedVersion)
    {
        var version = PacketParsingService.GetPacketType(binary);
        Assert.Equal(expectedVersion, version);
    }

    [Theory]
    [InlineData("11101110000000001101010000001100100000100011000001100000", 1)]
    [InlineData("00111000000000000110111101000101001010010001001000000000", 0)]
    public void GetLengthId(string binary, int expectedVersion)
    {
        var version = PacketParsingService.GetLengthTypeId(binary);
        Assert.Equal(expectedVersion, version);
    }

    [Theory]
    [InlineData("11101110000000001101010000001100100000100011000001100000", 3)]
    public void GetNumberOfSubpackets(string binary, int expectedVersion)
    {
        var version = PacketParsingService.GetNumberOfSubpackets(binary);
        Assert.Equal(expectedVersion, version);
    }

    [Theory]
    [InlineData("00111000000000000110111101000101001010010001001000000000", 27)]
    public void GetLengthOfSubpackets(string binary, int expectedVersion)
    {
        var version = PacketParsingService.GetLengthOfSubpackets(binary);
        Assert.Equal(expectedVersion, version);
    }

    [Theory]
    [InlineData("01010000001", 1)]
    [InlineData("10010000010", 2)]
    [InlineData("00110000011", 3)]
    public void GetLiteralValueFromPacket(string binary, int expectedVersion)
    {
        var version = PacketParsingService.GetLiteralValueFromPacket(binary);
        Assert.Equal(expectedVersion, version);
    }

    [Theory]
    [InlineData("00111000000000000110111101000101001010010001001000000000", 2)]
    [InlineData("11101110000000001101010000001100100000100011000001100000", 3)]
    public void GetSubPackets_Count(string binary, int expectedCount)
    {
        var version = PacketParsingService.GetSubPackets(binary);
        Assert.Equal(expectedCount, version.Count);
    }

    [Theory]
    [InlineData("00111000000000000110111101000101001010010001001000000000", 4)]
    [InlineData("11101110000000001101010100001100100000100011000001100000", 5)]
    public void GetSubPackets_TypeId(string binary, int expectedCount)
    {
        var version = PacketParsingService.GetSubPackets(binary);
        Assert.Equal(expectedCount, version[0].PacketType);
    }

    [Theory]
    [InlineData("0001000101010110001011", "00010001010", "10110001011")]
    public void GetFirstLiteral(string binary, string expected, string expectedRemaining)
    {
        var (literal, remaining) = PacketParsingService.GetFirstPacketForLiteralAndRemaining(binary);
        Assert.Equal(expected, literal.Binary);
        Assert.Equal(expectedRemaining, remaining);
    }

    [Theory]
    [InlineData("00000000000000000101100001000101010110001011001000100000000010000100011000111000110100", "00000000000000000101100001000101010110001011", "001000100000000010000100011000111000110100")]
    public void GetFirstTypeZero(string binary, string expected, string expectedRemaining)
    {
        var (literal, remaining) = PacketParsingService.GetFirstPacketForTypeZeroAndRemaining(binary);
        Assert.Equal(expected, literal.Binary);
        Assert.Equal(expectedRemaining, remaining);
    }

    [Theory]
    [InlineData("001000100000000010000100011000111000110100000000000000000101100001000101010110001011", "0010001000000000100001000110001110001101", "00000000000000000101100001000101010110001011")]
    public void GetFirstTypeOne(string binary, string expected, string expectedRemaining)
    {
        var (literal, remaining) = PacketParsingService.GetFirstPacketForTypeOneAndRemaining(binary);
        Assert.Equal(expected, literal.Binary);
        Assert.Equal(expectedRemaining, remaining);
    }
}