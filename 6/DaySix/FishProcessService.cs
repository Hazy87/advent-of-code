using System.Collections.Concurrent;

public class FishProcessService : IFishProcessService
{
    public void Process(List<LanternFish> fish)
    {
        var newlySpawned = new ConcurrentBag<LanternFish>();
        Parallel.ForEach(fish, new ParallelOptions { MaxDegreeOfParallelism = 2000 }, lanternFish =>
        {
            if (lanternFish.SpawnTimer == 0)
            {
                newlySpawned.Add(new LanternFish());
                lanternFish.SpawnTimer = 6;
                return;
            }

            lanternFish.SpawnTimer--;
        });

        fish.AddRange(newlySpawned);
    }
}