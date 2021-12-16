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

    public int GetPacketType(string binary)
    {
        return Convert.ToInt32(binary.Substring(3, 3), 2);
    }

    public int GetLengthTypeId(string binary)
    {
        return Convert.ToInt32(binary.Substring(6, 1), 2);
    }

    public int GetVersion(string binary)
    {
        return Convert.ToInt32(binary.Substring(0, 3), 2);
    }

    public int GetNumberOfSubpackets(string binary)
    {
        return Convert.ToInt32(binary.Substring(7, 11), 2);
    }

    public int GetLengthOfSubpackets(string binary)
    {
        return Convert.ToInt32(binary.Substring(7, 15), 2);
    }

    public int GetLiteralValueFromPacket(string binary)
    {
        var counter = 0;
        var literalValues = binary.Substring(6).ToCharArray().Chunk(5);
        foreach (var literalValue in literalValues)
        {
            counter += Convert.ToInt32(string.Join("",literalValue).ToString(), 2);
            if (literalValue[0] == 0)
                return counter;
        }

        return counter;
    }

    public List<string> GetSubPackets(string binary, int lengthTypeId)
    {
        var returnList = new List<string>();
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
            while (!ended)
            {
                var (packet, remaining) = GetPacketAndRemaining(subpackets);
                returnList.Add(packet);
                subpackets = remaining;
                if (remaining.Length == 0 || remaining.Replace("0","").Length == 0)
                    ended = true;
            }
        }

        return returnList;
    }

    public (string?, string) GetPacketAndRemaining(string subpackets)
    {
        if (GetPacketType(subpackets) == 4)
        {
            var firstPacket = GetFirstPacketForLiteral(subpackets);

            return (firstPacket, subpackets.Substring(firstPacket.Length));
        }
         
        var mysubpackets = GetSubPackets(subpackets, GetLengthTypeId(subpackets));


        var substring = subpackets.Substring(mysubpackets[0].Length);
        return (mysubpackets.FirstOrDefault(), substring);
    }

    public string GetFirstPacketForLiteral(string subpackets)
    {
        var valuesAndRemaining = subpackets.Substring(6);
        var firstPacket = new StringBuilder();
        firstPacket.Append(subpackets.Substring(0,6));
        foreach (var chunk in valuesAndRemaining.Chunk(5))
        {
            firstPacket.Append(chunk[..]);
            if (chunk[0] == '0')
            {
                return firstPacket.ToString();
            }
        }
        return null;
    }
}