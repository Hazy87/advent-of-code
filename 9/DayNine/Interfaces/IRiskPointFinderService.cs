namespace DayNine.Interfaces;

public interface IRiskPointFinderService
{
    List<int> FindRiskPoints(List<int> previous, List<int> lineToCheck, List<int> nextLine);
}