using DayNine.Interfaces;

namespace DayNine.Services;

public class RiskPointFinderService : IRiskPointFinderService
{
    public List<int> FindRiskPoints(List<int> previous, List<int> lineToCheck, List<int> nextLine)
    {
        var returnList = new List<int>();
        for (var i = 0; i < lineToCheck.Count; i++)
        {
            var previousNumber = int.MaxValue;
            if (i > 0)
                previousNumber = lineToCheck[i-1];
            var nextNumber = int.MaxValue;
            if (i < lineToCheck.Count - 1)
                nextNumber = lineToCheck[i + 1];
            if (previousNumber > lineToCheck[i] && nextNumber > lineToCheck[i])
            {
                var numberAbove = previous[i];
                var numberBelow = nextLine[i];
                if (numberBelow > lineToCheck[i] && numberAbove > lineToCheck[i])
                {
                    returnList.Add(lineToCheck[i] + 1);
                }
            }
        }
        return returnList;
    }
}