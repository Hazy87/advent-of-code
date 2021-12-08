namespace DayEight.Interfaces;

public interface INumberFindingService
{
    (string zero, string six, string nine) SplitSixNineZero(List<string> sixNineAndZero, string one, string four, string seven);
    (string two, string three, string five) SplitTwoThreeAndFive(List<string> twoThreeAndFive, string one, string nine);
}