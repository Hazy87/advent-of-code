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

    [Fact]
    public void Test_Five()
    {
        var packet = new Packet("620080001611562C8802118E34", true);
        Assert.Equal(2, packet.SubPackets.Count);
        Assert.Equal(12, packet.VersionSum);
        
    }

    [Fact]
    public void Test_Six()
    {
        var packet = new Packet("00000000000000000101100001000101010110001011");
        Assert.Equal(2, packet.SubPackets.Count);
        Assert.Equal(12, packet.VersionSum);

    }
}