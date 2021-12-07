public class FuelCalculatorService : IFuelCalculatorService
{
    public int GetMinimumFuelRequired(int[] postitions)
    {
        var orderedList = postitions.OrderBy(x => x);
        var minFuelCounter = int.MaxValue;
        for (int newPosition = 0; newPosition < orderedList.Max(); newPosition++)
        {
            var totalFuelCounter = 0;
            foreach (var oldPosition in orderedList)
            {
                var difference = oldPosition - newPosition;
                if (difference < 0)
                    difference = difference * -1;
                totalFuelCounter += difference;
            }
            if(totalFuelCounter < minFuelCounter)
                minFuelCounter = totalFuelCounter;
        }

        return minFuelCounter;
    }

    public int GetMinimumFuelRequiredFuelRates(int[] postitions)
    {
        var orderedList = postitions.OrderBy(x => x);
        var minFuelCounter = int.MaxValue;
        for (int newPosition = 0; newPosition < orderedList.Max(); newPosition++)
        {
            var totalFuelCounter = 0;
            foreach (var oldPosition in orderedList)
            {
                var difference = GetFuelRate(oldPosition,newPosition);

                totalFuelCounter += difference;
            }
            if (totalFuelCounter < minFuelCounter)
                minFuelCounter = totalFuelCounter;
        }

        return minFuelCounter;
    }

    public int GetFuelRate(int oldPosition, int newPosition)
    {
        var rate = oldPosition - newPosition;
        if (rate < 0)
            rate *= -1;
        var lastValue = 0;
        var finalValue = 0;
        for (var i = 0; i < rate; i++)
        {
            finalValue += lastValue + 1;
            lastValue++;
        }
        return finalValue;
    }
}