using System.Collections.Concurrent;

public class FishProcessService : IFishProcessService
{
    
    public static ConcurrentDictionary<(int spawnTimer, int days), long> RainbowTable = new();

    public long CountFishChildren(int spawnTimer, int days)
    {
        if (RainbowTable.ContainsKey((spawnTimer, days)))
            return RainbowTable[(spawnTimer, days)];
        long fishCounter = 0;
        for (var i = 1; i < days + 1; i++)
        {
            if (spawnTimer > days)
                return fishCounter;
            if (spawnTimer == 0)
            {
                fishCounter += CountFishChildren(8, days - i);
                fishCounter++;
                spawnTimer = 6;
                RainbowTable[(spawnTimer, days)] = fishCounter;
            }
            else
            {
                spawnTimer--;
            }
        }

        return fishCounter;
    }

    public long CountFishChildrenParral(int spawnTimer, int days)
    {
        if (RainbowTable.ContainsKey((spawnTimer, days)))
            return RainbowTable[(spawnTimer, days)];
        long fishCounter = 0;
        for (var i = 1; i < days + 1; i++)
        {
            if (spawnTimer > days)
                return fishCounter;
            if (spawnTimer == 0)
            {
                fishCounter += CountFishChildren(8, days - i);
                fishCounter++;
                spawnTimer = 6;
                RainbowTable[(spawnTimer, days)] = fishCounter;
            }
            else
            {
                spawnTimer--;
            }
        }

        return fishCounter;
    }
}