public interface IInputService
{
    Task<IEnumerable<List<int>>> GetLines();
}