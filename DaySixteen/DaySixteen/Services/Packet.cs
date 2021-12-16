namespace DaySixteen.Services;

public class Packet
{
    public Packet(string binary)
    {
        Binary = binary;
    }

    public Packet(string hex, bool b)
    {
        Binary = HexadecimalConverterService.ConvertHexToBinary(hex);
    }

    public string Binary { get; }

    public int LengthType => PacketParsingService.GetLengthTypeId(Binary);
    public int VersionId => PacketParsingService.GetVersion(Binary);
    public int PacketType => PacketParsingService.GetPacketType(Binary);
    public long? Literal {
        get
    {
        if (PacketType != 4)
            return null;
        return PacketParsingService.GetLiteralValueFromPacket(Binary);
    }}

    private List<Packet>? _subPackets;
    public List<Packet>? SubPackets
    {
        get
        {
            if (PacketType == 4)
                return null;
            if (_subPackets == null)
            {
                _subPackets = PacketParsingService.GetSubPackets(LengthType == 0 ? Binary.Substring(22) : Binary.Substring(18));
            }

            return _subPackets;
        }
    }

    public int VersionSum
    {
        get
        {
            if (SubPackets != null) return VersionId + SubPackets.Select(x => x.VersionSum).Sum();
            return VersionId;
        }
    }

    public long Value
    {
        get
        {
            if (Literal != null)
                return Literal.Value;
            switch (PacketType)
            {
                case 0:
                    return SubPackets.Sum(x => x.Value);
                case 1:
                    return SubPackets.Select(x => x.Value).Aggregate((x, y) => x * y);
                case 2: return SubPackets.Min(x => x.Value);
                case 3: return SubPackets.Max(x => x.Value);
                case 5: return SubPackets[0].Value > SubPackets[1].Value ? 1 : 0;
                case 6: return SubPackets[0].Value < SubPackets[1].Value ? 1 : 0;
                case 7: return SubPackets[0].Value == SubPackets[1].Value ? 1 : 0;
            }

            return 0;
        }
    }
}