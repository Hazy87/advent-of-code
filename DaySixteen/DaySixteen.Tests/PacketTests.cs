using System.Linq;
using DaySixteen.Services;
using Microsoft.VisualBasic;
using Xunit;

namespace DaySixteen.Tests;

public class PacketTests
{
    [Fact]
    public void Test_One()
    {
        var packet = new Packet("D2FE28", true);
        Assert.Equal(6, packet.VersionId);
        Assert.Equal(4, packet.PacketType);
        Assert.Equal(2021, packet.Literal);
    }

    [Fact]
    public void Test_Two()
    {
        var packet = new Packet("38006F45291200", true);
        Assert.Equal(1, packet.VersionId);
        Assert.Equal(6, packet.PacketType);
        Assert.Equal(0, packet.LengthType);
        Assert.Equal(null, packet.Literal);
        Assert.Equal(2, packet.SubPackets.Count);
        Assert.True(packet.SubPackets.Any(x => x.Literal == 10));
        Assert.True(packet.SubPackets.Any(x => x.Literal == 20));

    }

    [Fact]
    public void Test_Three()
    {
        var packet = new Packet("EE00D40C823060", true);
        Assert.Equal(7, packet.VersionId);
        Assert.Equal(3, packet.PacketType);
        Assert.Equal(1, packet.LengthType);
        Assert.Equal(null, packet.Literal);
        Assert.Equal(3, packet.SubPackets.Count);
        Assert.True(packet.SubPackets.Any(x => x.Literal == 1));
        Assert.True(packet.SubPackets.Any(x => x.Literal == 2));
        Assert.True(packet.SubPackets.Any(x => x.Literal == 3));
    }

    [Fact]
    public void Test_Four()
    {
        var packet = new Packet("8A004A801A8002F478", true);
        Assert.Equal(4, packet.VersionId);
        Assert.Equal(16, packet.VersionSum);
        Assert.Equal(1, packet.SubPackets.Count);
        Assert.Equal(16, packet.VersionSum);
        Assert.True(packet.SubPackets.Any(x => x.VersionId == 1));
        Assert.True(packet.SubPackets.Any(x => x.SubPackets.Count == 1));
        Assert.True(packet.SubPackets.Any(x => x.SubPackets.Any(y => y.VersionId == 5)));

        Assert.True(packet.SubPackets.Any(x => x.SubPackets.First(y => y.VersionId == 5).SubPackets.Count == 1));
        Assert.True(packet.SubPackets.Any(x => x.SubPackets.First(y => y.VersionId == 5).SubPackets.Any(z => z.VersionId == 6)));
    }

    [Theory]
    [InlineData("8A004A801A8002F478", 16)]
    [InlineData("620080001611562C8802118E34", 12)]
    [InlineData("C0015000016115A2E0802F182340", 23)]
    [InlineData("A0016C880162017C3686B18A3D4780", 31)]
    public void Test_Five(string hex, int expectedVersionSum)
    {
        var packet = new Packet(hex, true);
        Assert.Equal(expectedVersionSum, packet.VersionSum);
    }

    [Theory]
    [InlineData("C200B40A82", 3)]
    [InlineData("04005AC33890", 54)]
    [InlineData("880086C3E88112", 7)]
    [InlineData("CE00C43D881120", 9)]
    [InlineData("D8005AC2A8F0", 1)]
    [InlineData("F600BC2D8F", 0)]
    [InlineData("9C005AC2F8F0", 0)]
    [InlineData("9C0141080250320F1802104A08", 1)]
    public void Maths(string hex, int expectedValue)
    {
        var packet = new Packet(hex, true);
        Assert.Equal(expectedValue, packet.Value);

    }
}