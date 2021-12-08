namespace DayEight.Services;

public class NumberFindingService : INumberFindingService
{

    public (string two, string three, string five) SplitTwoThreeAndFive(List<string> twoThreeAndFive,string one, string nine)
    {
        var two = twoThreeAndFive.Single(x => GetNumberOfMatches(x, nine, 4));
        var three = twoThreeAndFive.Single(x => GetNumberOfMatches(x, nine, 5) && GetNumberOfMatches(x, one, 2));
        var five = twoThreeAndFive.Single(x => x != three && x != two);
        return (two, three, five);

    }

    
    public (string zero, string six, string nine) SplitSixNineZero(List<string> sixNineAndZero, string one, string four, string seven)
    {
        var nine = sixNineAndZero.Single(x => x.Contains(one[0]) && x.Contains(one[1]) && x.Contains(four[0]) && x.Contains(four[1]) && x.Contains(four[2]) && x.Contains(four[3]));
        var six = sixNineAndZero.Single(x => x != nine && GetNumberOfMatches(x, seven, 2));
        var zero = sixNineAndZero.Single(x => x != six && x != nine);
        return (zero, six, nine);
    }

    private bool GetNumberOfMatches(string compareA, string compareB, int requiredMatches)
    {
        var counter = 0;
        foreach (var myChar in compareA)
        {
            if (compareB.Contains(myChar))
                counter++;
        }

        return counter == requiredMatches;
    }


}