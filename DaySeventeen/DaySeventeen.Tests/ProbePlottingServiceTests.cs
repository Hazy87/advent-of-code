using System.Runtime.InteropServices.ComTypes;
using DaySeventeen.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DaySeventeen.Tests;

[TestClass]
public class ProbePlottingServiceTests
{
    private readonly ProbePlottingService _service;

    public ProbePlottingServiceTests()
    {
        _service = new ProbePlottingService();
    }
    [Theory]
    [InlineData(1,1,6,5,5,4,7,6)]
    [InlineData(1,1,6,0,5,-1,7,1)]
    [InlineData(1,1,0,0,0,-1,1,1)]
    public void Plot_Step(int currentXPosition, int currentYPosition, int xVelocity, int yVelocity, int expectedXVelocity, int expectedYVelocity, int expectedXPostition, int expectedYPosition)
    {
        var (xPosition, yPosition, returnedXVelocity, returnedYelocity) = _service.PlotStep(currentXPosition, currentYPosition, xVelocity, yVelocity);
        Assert.AreEqual(expectedXPostition, xPosition);
        Assert.AreEqual(expectedYPosition, yPosition);
        Assert.AreEqual(expectedYVelocity, returnedYelocity);
        Assert.AreEqual(expectedXVelocity, returnedXVelocity);
    }

    [Theory]
    [InlineData(1, 1, false)]
    [InlineData(25, 1, false)]
    [InlineData(1, -10, false)]
    [InlineData(25, -10, true)]
    [InlineData(30, -5, true)]
    [InlineData(20, -63, true)]
    public void IsInTrench(int x , int y, bool expectedResult )
    {
        var input = new Input { MaxX = 30, MinX = 20, MaxY = -5, MinY = -63 };
        var result = _service.IsIntrench(input, x, y);
        Assert.AreEqual(expectedResult, result);
    }

    [Theory]
    [InlineData(1, 1, false)]
    [InlineData(25, 1, false)]
    [InlineData(32, -10, true)]
    [InlineData(32, -70, true)]
    [InlineData(1, -6, false)]
    [InlineData(20, -67, true)]
    public void HasOverShotTrench(int x, int y, bool expectedResult)
    {
        var input = new Input { MaxX = 30, MinX = 20, MaxY = -5, MinY = -63 };
        var result = _service.HasOverShotTrench(input, x, y);
        Assert.AreEqual(expectedResult, result);
    }

    [Theory]
    [InlineData(6, 3, 6)]
    [InlineData(6, 9, 45)]
    [InlineData(9, 0, 0)]
    [InlineData(17, -4, null)]
    [InlineData(7, 2, 3)]
    [InlineData(1, 1, null)]
    [InlineData(7, 20, null)]
    public void HighestPoint(int xVelocity, int yvelocity, int? highestPoint)
    {
        var input = new Input { MaxX = 30, MinX = 20, MaxY = -5, MinY = -10 };
        var result = _service.HighestPoint(xVelocity, yvelocity, input);
        Assert.AreEqual(highestPoint, result);
    }
}