using DayThirteen.Services;
using Xunit;

namespace DayThirteen.Tests;

public class FoldServiceTests
{
    private readonly FoldService _service;

    public FoldServiceTests()
    {
        _service = new FoldService();
    }

    [Theory]
    [InlineData(1,2,4,true)]
    [InlineData(2,1,4,true)]
    [InlineData(14,22,40,false)]
    [InlineData(14,2,40,false)]
    public void Fold_Coordinate_ShouldReturnSameCoordinate_IfAboveFold(int x, int y, int foldline, bool yfold)
    {
        var newCoordinate = _service.GetNewCoordinateAfterFold((x,y), (yfold, foldline));
        Assert.Equal(x, newCoordinate.X);
        Assert.Equal(y, newCoordinate.Y);
    }

    [Theory]
    [InlineData(7, 7 , 6, true, 7, 5)]
    [InlineData(0, 14 , 7, true, 0, 0)]
    [InlineData(2, 14 , 7, true, 2, 0)]
    [InlineData(8, 8 , 6, true, 8, 4)]
    [InlineData(8, 8 , 6, false, 4, 8)]
    [InlineData(4, 5 , 3, false, 2, 5)]
    public void Fold_Coordinate_ShouldReturnCorrectCoordinate_IfBelowFold(int x, int y, int foldline, bool yfold, int expectedx, int expectedy)
    {
        var newCoordinate = _service.GetNewCoordinateAfterFold((x, y ), (yfold, foldline));
        Assert.Equal(expectedx, newCoordinate.X);
        Assert.Equal(expectedy, newCoordinate.Y);
    }
}