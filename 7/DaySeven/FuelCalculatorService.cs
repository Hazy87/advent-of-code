public class FuelCalculatorService : IFuelCalculatorService
{
    public int GetMinimumFuelRequired(int[] postitions)
    {
        var orderedList = postitions.OrderBy(x => x);
        var minFuelCounter = Int32.MaxValue;
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
}