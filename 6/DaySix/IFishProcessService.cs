public interface IFishProcessService
{
    int CountFishChildren(LanternFish fish, int days);
    void Process(List<LanternFish> originalFish);
}