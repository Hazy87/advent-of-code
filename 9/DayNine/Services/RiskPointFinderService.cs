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

    public List<int> BasinFinder(List<List<int>> lines)
    {
        var returnList = new List<int>();
        for (int i = 0; i <= lines.Count-1; i++)
        {
            var line = lines[i];
            for (int j = 0; j <= line.Count-1; j++)
            {
                var column = line[j];
                if (column < 9)
                {
                    var basinSize = Explore(lines, lines.IndexOf(line), line.IndexOf(column));
                    returnList.Add(basinSize);
                }
            }
        }

        return returnList.OrderByDescending(x => x).Take(3).ToList();
    }

    private int Explore(List<List<int>> lines, int lineIndex, int columnIndex)
    {
        var counter = 1;
        lines[lineIndex][columnIndex] = 10;
        if (LookLeft(lines, lineIndex, columnIndex) < 9)
        {
            counter += Explore(lines, lineIndex, columnIndex - 1);
        }
        if (LookRight(lines, lineIndex, columnIndex) < 9)
        {
            counter += Explore(lines, lineIndex, columnIndex +1);
        }
        if (LookUp(lines, lineIndex, columnIndex) < 9)
        {
            counter += Explore(lines, lineIndex-1, columnIndex );
        }
        if (LookDown(lines, lineIndex, columnIndex) < 9)
        {
            counter += Explore(lines, lineIndex+1, columnIndex);
        }

        return counter;
    }

    private int LookLeft(List<List<int>> lines, int lineIndex, int rowIndex)
    {
        if (rowIndex == 0)
            return int.MaxValue;
        return lines[lineIndex][rowIndex - 1];
    }
    private int LookRight(List<List<int>> lines, int lineIndex, int rowIndex)
    {
        if (rowIndex == lines[0].Count-1)
            return int.MaxValue;
        return lines[lineIndex][rowIndex + 1];
    }
    private int LookUp(List<List<int>> lines, int lineIndex, int rowIndex)
    {
        if (lineIndex == 0)
            return int.MaxValue;
        return lines[lineIndex-1][rowIndex];
    }
    private int LookDown(List<List<int>> lines, int lineIndex, int rowIndex)
    {
        if (lineIndex == lines.Count-1)
            return int.MaxValue;
        return lines[lineIndex+1][rowIndex];
    }
}