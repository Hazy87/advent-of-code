
namespace DayThirteen.Services;

public class InputService :IInputService
{
    public async Task<(List<Coordinate> coordinates, List<Fold> folds)> GetInput()
    {
        var lines = (await File.ReadAllLinesAsync("input.txt")).Where(x => !string.IsNullOrWhiteSpace(x));
        var coords = lines.Where(x => !x.StartsWith("fold")).Select(CoordinateMapper.Map);
        var folds = lines.Where(x => x.StartsWith("fold")).Select(FoldMapper.Map);
        return (coords.ToList(), folds.ToList());
    }
    
}