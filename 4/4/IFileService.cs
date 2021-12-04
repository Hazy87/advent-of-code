namespace _4;

public interface IFileService
{
    Task<string[]> GetNumbersAsync();
    Task<IEnumerable<string[]>> GetBoardNumbersAsync();
}
