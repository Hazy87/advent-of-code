public interface IFuelCalculatorService
{
    int GetMinimumFuelRequired(int[] postitions);
    int GetMinimumFuelRequiredFuelRates(int[] postitions);
    int GetFuelRate(int oldPosition, int newPosition);
}