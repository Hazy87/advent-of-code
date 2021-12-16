using System.Net.NetworkInformation;
using System.Text;

namespace DaySixteen.Services;

public class PacketParsingService : IPacketParsingService
{
    public void Parse(string binary)
    {
        var version = GetVersion(binary);
        var getType = GetPacketType(binary);
        var getLengthTypeId = GetLengthTypeId(binary);
    }

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

    public static int GetLiteralValueFromPacket(string binary)
    {
        var counter = "";
        var literalValues = binary.Substring(6).ToCharArray().Chunk(5);
        foreach (var literalValue in literalValues.Where(x => x.Length == 5))
        {
            counter += string.Join("",literalValue)[1..].ToString();
            if (literalValue[0] == 0)
                return Convert.ToInt32(counter,2);
        }

        return Convert.ToInt32(counter, 2);
    }

    public static List<Packet> GetSubPackets(string binary)
    {
        var lengthTypeId = GetLengthTypeId(binary);
        var returnList = new List<Packet>();
        if (lengthTypeId == 0)
        {
            var length = GetLengthOfSubpackets(binary);

            var subpackets = binary.Substring(22 , length);
            bool ended = false;
            while (!ended)
            {
                var (packet, remaining) = GetPacketAndRemaining(subpackets);
                returnList.Add(packet);
                subpackets = remaining;
                if (remaining.Length == 0)
                    ended = true;
            }
        }
        if (lengthTypeId == 1)
        {
            var length = GetNumberOfSubpackets(binary);
            var subpackets = binary.Substring(18);
            bool ended = false;
            for (int i = 0; i < length; i++)
            {
                if(string.IsNullOrEmpty(subpackets))
                    continue;
                var (packet, remaining) = GetPacketAndRemaining(subpackets);
                returnList.Add(packet);
                subpackets = remaining;
            }
        }

        return returnList;
    }

    public static (Packet?, string substring) GetPacketAndRemaining(string subpackets)
    {
        if (GetPacketType(subpackets) == 4)
        {
            var firstPacket = GetFirstPacketForLiteral(subpackets);

            return (firstPacket, subpackets.Substring(firstPacket.Binary.Length));
        }

        var packet = new Packet(subpackets);
        return (packet, subpackets.Substring(packet.Binary.Length));
        var mysubpackets = GetSubPackets(subpackets);


        var substring = subpackets.Substring(mysubpackets[0].Binary.Length);
        return (mysubpackets.FirstOrDefault(), substring);
    }

    public static Packet GetFirstPacketForLiteral(string subpackets)
    {
        var valuesAndRemaining = subpackets.Substring(6);
        var firstPacket = new StringBuilder();
        firstPacket.Append(subpackets.Substring(0,6));
        foreach (var chunk in valuesAndRemaining.Chunk(5))
        {
            firstPacket.Append(chunk[..]);
            if (chunk[0] == '0')
            {
                return new Packet (firstPacket.ToString());
            }
        }
        return null;
    }
}