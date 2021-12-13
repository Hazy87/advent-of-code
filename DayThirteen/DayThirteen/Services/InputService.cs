
namespace DayThirteen.Services;

public class InputService :IInputService
{
    public async Task<(IEnumerable<(int X, int Y)> coordinates, IEnumerable<(bool IsYFold, int FoldLine)> folds)> GetInput()
    {
        var lines = (await File.ReadAllLinesAsync("input.txt")).Where(x => !string.IsNullOrWhiteSpace(x));
        var coords = lines.Where(x => !x.StartsWith("fold")).Select(CoordinateMapper.Map);
        var folds = lines.Where(x => x.StartsWith("fold")).Select(FoldMapper.Map);
        return (coords, folds);
    }
    
}