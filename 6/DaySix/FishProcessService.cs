using System.Collections.Concurrent;

public class FishProcessService : IFishProcessService
{
    

    public int CountFishChildren(LanternFish fish, int days)
    {
        var counter = 0;
        var fishCounter = 0;
        for (int i = 1; i < days+1; i++)
        {
            if (fish.SpawnTimer > days)
                return fishCounter;
            if (fish.SpawnTimer == 0)
            {
                fishCounter += CountFishChildren(new LanternFish { SpawnTimer = 8 }, days - i);
                fishCounter++;
                fish.SpawnTimer = 6;
            }
            else
            {
                fish.SpawnTimer--;
            }
        }
        return fishCounter;
    }

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