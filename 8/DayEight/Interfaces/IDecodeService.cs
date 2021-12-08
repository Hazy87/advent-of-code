namespace DayEight.Interfaces;

public interface IDecodeService
{
    int Decode(Dictionary<string, int> numbers, List<string> lineDigitalOutputsList);
}