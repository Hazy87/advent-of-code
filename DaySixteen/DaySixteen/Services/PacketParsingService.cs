using System.Text;

namespace DaySixteen.Services;

public class PacketParsingService
{
    public static int GetPacketType(string binary)
    {
        return Convert.ToInt32(binary.Substring(3, 3), 2);
    }

    public static int GetLengthTypeId(string binary)
    {
        return Convert.ToInt32(binary.Substring(6, 1), 2);
    }

    public static int GetVersion(string binary)
    {
        var version = Convert.ToInt32(binary.Substring(0, 3), 2);
        return version;
    }

    public static int GetNumberOfSubpackets(string binary)
    {
        return Convert.ToInt32(binary.Substring(7, 11), 2);
    }

    public static int GetLengthOfSubpackets(string binary)
    {
        return Convert.ToInt32(binary.Substring(7, 15), 2);
    }

    public static long GetLiteralValueFromPacket(string binary)
    {
        var counter = "";
        var literalValues = binary.Substring(6).ToCharArray().Chunk(5);
        foreach (var literalValue in literalValues.Where(x => x.Length == 5))
        {
            counter += string.Join("",literalValue)[1..];
            if (literalValue[0] == 0)
                return Convert.ToInt32(counter,2);
        }

        return Convert.ToInt64(counter, 2);
    }

    public static List<Packet>? GetSubPackets(string binary)
    {
        var remaining = binary;
        var subPackets = new List<Packet>();

        while (remaining.Length > 7)
        {
            var (packet, newRemaining) = GetFirstPacketRemaining(remaining);
            remaining = newRemaining;
            subPackets.Add(packet);
        }

        return subPackets;
    }

    public static (Packet literal, string remaining) GetFirstPacketRemaining(string subpackets)
    {
        if (GetPacketType(subpackets) == 4)
        {
            return GetFirstPacketForLiteralAndRemaining(subpackets);
        }

        if (GetLengthTypeId(subpackets) == 0)
        {
            return GetFirstPacketForTypeZeroAndRemaining(subpackets);
        }

        if (GetLengthTypeId(subpackets) == 1)
        {
            return GetFirstPacketForTypeOneAndRemaining(subpackets);
        }

        throw new Exception();
    }


    public static (Packet literal, string remaining) GetFirstPacketForLiteralAndRemaining(string subpackets)
    {
        var valuesAndRemaining = subpackets.Substring(6);
        var firstPacket = new StringBuilder();
        firstPacket.Append(subpackets.Substring(0,6));
        foreach (var chunk in valuesAndRemaining.Chunk(5))
        {
            firstPacket.Append(chunk[..]);
            if (chunk[0] == '0')
            {
                return (new Packet (firstPacket.ToString()), subpackets.Substring(firstPacket.Length));
            }
        }
        return (null, "")!;
    }

    public static (Packet literal, string remaining) GetFirstPacketForTypeZeroAndRemaining(string subpackets)
    {
        var length = GetLengthOfSubpackets(subpackets);
        return (new Packet(subpackets.Substring(0, 22 + length)), subpackets.Substring(22 + length));
    }

    public static (Packet literal, string remaining) GetFirstPacketForTypeOneAndRemaining(string subpackets)
    {
        var count = GetNumberOfSubpackets(subpackets);
        var content = subpackets.Substring(18);
        for (int i = 0; i < count; i++)
        {
            if (GetPacketType(content) == 4)
            {
                var (_, remaining) = GetFirstPacketForLiteralAndRemaining(content);
                content = remaining;
                continue;
            }

            if (GetLengthTypeId(content) == 0)
            {
                var (_, remaining) = GetFirstPacketForTypeZeroAndRemaining(content);
                content = remaining;
                continue;
            }
            if (GetLengthTypeId(content) == 1)
            {
                var (_, remaining) = GetFirstPacketForTypeOneAndRemaining(content);
                content = remaining;
                continue;
            }
        }
        return (new Packet(subpackets.Substring(0, subpackets.Length - content.Length)), content);
    }
}