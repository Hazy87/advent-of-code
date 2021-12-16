namespace DaySixteen.Interfaces;

public interface IPacketParsingService
{
    void Parse(string binary);
    int GetPacketType(string binary);
    int GetLengthTypeId(string binary);
    int GetVersion(string binary);
    int GetNumberOfSubpackets(string binary);
    int GetLengthOfSubpackets(string binary);
    int GetLiteralValueFromPacket(string binary);
    List<string> GetSubPackets(string binary, int lengthTypeId);
    (string?, string) GetPacketAndRemaining(string subpackets);
    string GetFirstPacketForLiteral(string subpackets);
}