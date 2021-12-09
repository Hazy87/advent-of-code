public class InputService :IInputService
{
    public async Task<IEnumerable<List<int>>> GetLines()
    {
        var lines = await File.ReadAllLinesAsync("input.txt");
        var enumerable = lines.Select(x => x.ToCharArray().Select(y => int.Parse(y.ToString())));
        var returnList = new List<List<int>>();
        returnList.Add(GetMaxHeightLines(lines[0].Length));
        foreach (var line in enumerable)
        {
            returnList.Add(line.ToList());

        }
        returnList.Add(GetMaxHeightLines(lines[0].Length));

        return returnList;
    }

    private static List<int> GetMaxHeightLines(int length)
    {
        var numberOfRows = length;
        var maxHeightLines = new List<int>();
        for (int i = 0; i < numberOfRows; i++)
        {
            maxHeightLines.Add(int.MaxValue);
        }

        return maxHeightLines;
    }
}