namespace DayEight.Services;

public class DecodeService : IDecodeService
{
    public int Decode(Dictionary<string, int> numbers, List<string> lineDigitalOutputsList)
    {
        string number = "";
        foreach (var digital in lineDigitalOutputsList)
        {
            number += numbers[ProcessRunner.SortString(digital)];
        }

        return int.Parse(number);
    }
}