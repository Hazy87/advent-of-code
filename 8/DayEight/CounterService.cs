public class CounterService : ICounterService
{
    public int Count(IEnumerable<Input> lines)
    {
        var counter = 0;
        foreach (var line in lines)
        {
            counter += line.DigitalOutputsList.Where(x => x.Length == 2).Count();

            counter += line.DigitalOutputsList.Where(x => x.Length == 4).Count();

            counter += line.DigitalOutputsList.Where(x => x.Length == 3).Count();

            counter += line.DigitalOutputsList.Where(x => x.Length == 7).Count();

        }

        return counter;
    }
}