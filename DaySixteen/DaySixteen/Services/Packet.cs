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
    public int? Literal {
        get
    {
        if (PacketType != 4)
            return null;
        return PacketParsingService.GetLiteralValueFromPacket(Binary);
    }}

    public List<Packet> SubPackets
    {
        get
        {
            if (PacketType == 4)
                return null;
            return PacketParsingService.GetSubPackets(Binary);
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
}