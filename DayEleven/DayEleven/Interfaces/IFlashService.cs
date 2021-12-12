namespace DayEleven.Interfaces;

public interface IFlashService
{
    void IncrementAll(List<Octopus> octopuses);
    int Flash(List<Octopus> input);
}