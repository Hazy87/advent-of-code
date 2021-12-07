public interface IInputService
{
    Task<IEnumerable<int>> GetPositions();
}