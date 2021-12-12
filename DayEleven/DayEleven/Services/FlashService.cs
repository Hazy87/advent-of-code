namespace DayEleven.Services;

class FlashService : IFlashService
{
    public void IncrementAll(List<Octopus> octopuses)
    {
        foreach (var octopus in octopuses)
        {
            octopus.Energy++;
            octopus.Flashed = false;
        }
    }

    public int Flash(List<Octopus> octopuses)
    {
        var flashCount = 0;
        foreach (var octopus in octopuses)
        {
            if (octopus.Energy > 9)
            {
                flashCount++;
                octopus.Energy = 0;
                octopus.Flashed = true;
                flashCount += IncrementNeighbours(octopuses, octopus);
            }
        }

        return flashCount;
    }

    private int IncrementNeighbours(List<Octopus> octopuses, Octopus octopus)
    {
        var flashCounter = 0;
        var up = octopuses.SingleOrDefault(innerOctopus =>
            innerOctopus.X == octopus.X && innerOctopus.Y == octopus.Y - 1);
        flashCounter += FlashIfNeeded(octopuses, up);

        var upLeft = octopuses.SingleOrDefault(innerOctopus =>
            innerOctopus.X == octopus.X-1 && innerOctopus.Y == octopus.Y - 1);
        flashCounter += FlashIfNeeded(octopuses, upLeft);

        var upRight = octopuses.SingleOrDefault(innerOctopus =>
            innerOctopus.X == octopus.X+1 && innerOctopus.Y == octopus.Y - 1);
        flashCounter += FlashIfNeeded(octopuses, upRight);

        var Down = octopuses.SingleOrDefault(innerOctopus =>
            innerOctopus.X == octopus.X && innerOctopus.Y == octopus.Y + 1);
        flashCounter += FlashIfNeeded(octopuses, Down);

        var DownpRight = octopuses.SingleOrDefault(innerOctopus =>
            innerOctopus.X == octopus.X+1 && innerOctopus.Y == octopus.Y + 1);
        flashCounter += FlashIfNeeded(octopuses, DownpRight);

        var DownLeft = octopuses.SingleOrDefault(innerOctopus =>
            innerOctopus.X == octopus.X-1 && innerOctopus.Y == octopus.Y + 1);
        flashCounter += FlashIfNeeded(octopuses, DownLeft);

        var Left = octopuses.SingleOrDefault(innerOctopus =>
            innerOctopus.X == octopus.X - 1 && innerOctopus.Y == octopus.Y);
        flashCounter += FlashIfNeeded(octopuses, Left);

        var Right = octopuses.SingleOrDefault(innerOctopus =>
            innerOctopus.X == octopus.X + 1 && innerOctopus.Y == octopus.Y);
        flashCounter += FlashIfNeeded(octopuses, Right);

        return flashCounter;
    }

    private int FlashIfNeeded(List<Octopus> octopuses, Octopus? neighbour)
    {
        var flashCounter = 0;
        if (neighbour != null)
        {
            if(!neighbour.Flashed)
                neighbour.Energy++;
            if (neighbour.Energy > 9)
            {
                neighbour.Energy = 0;
                neighbour.Flashed = true;
                flashCounter+=IncrementNeighbours(octopuses, neighbour);
                flashCounter++;
            }
        }

        return flashCounter;
    }
}