using System.Text;

namespace DaySixteen.Services;

public class HexadecimalConverterService : IHexadecimalConverterService
{
    public static string ConvertHexToBinary(string hexadecimal)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hexadecimal.Length; i++)
        {
            sb.Append(Convert.ToString(Convert.ToInt64(hexadecimal[i].ToString(), 16), 2).PadLeft(4, '0'));
        }
        return sb.ToString();
    }
}