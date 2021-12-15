using System.Collections.Generic;
using System.Linq;
using DayFifteen.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Xunit.Assert;

namespace DayFifteen.Tests;

[TestClass]
public class InputServiceTests
{
    private readonly InputService _service;

    public InputServiceTests()
    {
        _service = new InputService();
    }
    [Fact]
    public void IncreaseGridSize()
    {
        var grid = new Grid
        {
            Nodes = new List<Node>
            {
                new()
                {
                    Distance = 1,
                    X = 1,
                    Y = 1
                }
            }
        };
        _service.IncreaseGridSize(grid, 2);
        Assert.Equal(4, grid.Nodes.Count);
    }

    [Fact]
    public void IncreaseGridSize_CheckRiskFactor()
    {
        var grid = new Grid
        {
            Nodes = new List<Node>
            {
                new()
                {
                    RiskFactor = 1,
                    X = 1,
                    Y = 1
                }
            }
        };
        _service.IncreaseGridSize(grid, 2);
        Assert.Equal(4, grid.Nodes.Count);
        Assert.Equal(2, grid.Nodes.Where(x => x.RiskFactor == 2).Count());
    }

    [Fact]
    public void IncreaseGridSize_CheckRiskFactor_Other()
    {
        var grid = new Grid
        {
            Nodes = new List<Node>
            {
                new()
                {
                    RiskFactor = 5,
                    X = 1,
                    Y = 1
                }
            }
        };
        _service.IncreaseGridSize(grid, 2);
        Assert.Equal(4, grid.Nodes.Count);
        Assert.Equal(2, grid.Nodes.Where(x => x.RiskFactor == 6).Count());
    }

    [Fact]
    public void IncreaseGridSize_CheckRiskFactor_CheckX()
    {
        var grid = new Grid
        {
            Nodes = new List<Node>
            {
                new()
                {
                    RiskFactor = 5,
                    X = 1,
                    Y = 1
                }
            },
            XSize = 1,
            YSize = 1
        };
        _service.IncreaseGridSize(grid, 2);
        Assert.Equal(4, grid.Nodes.Count);
        Assert.Equal(2, grid.Nodes.Where(x => x.RiskFactor == 6).Count());
        Assert.Equal(1, grid.Nodes.Where(x => x.RiskFactor == 6 && x.X == 2).Count());
        Assert.Equal(1, grid.Nodes.Where(x => x.RiskFactor == 6 && x.X == 1).Count());
    }

    [Fact]
    public void IncreaseGridSize_CheckRiskFactor_CheckY()
    {
        var grid = new Grid
        {
            Nodes = new List<Node>
            {
                new()
                {
                    RiskFactor = 5,
                    X = 1,
                    Y = 1
                }
            },
            XSize = 1,
            YSize = 1
        };
        _service.IncreaseGridSize(grid, 2);
        Assert.Equal(4, grid.Nodes.Count);
        Assert.Equal(2, grid.Nodes.Where(x => x.RiskFactor == 6).Count());
        Assert.Equal(1, grid.Nodes.Where(x => x.RiskFactor == 6 && x.Y == 2).Count());
    }

    [Fact]
    public void IncreaseGridSize_CheckRiskFactor_Big()
    {
        var grid = new Grid
        {
            Nodes = new List<Node>
            {
                new()
                {
                    RiskFactor = 15,
                    X = 0,
                    Y = 0
                },
                new()
                {
                    RiskFactor = 7,
                    X = 1,
                    Y = 1
                },
                new()
                {
                    RiskFactor = 33,
                    X = 0,
                    Y = 1
                },
                new()
                {
                    RiskFactor = 1,
                    X = 1,
                    Y = 0
                }
            },
            XSize = 2,
            YSize = 2
        };
        _service.IncreaseGridSize(grid, 2);
        Assert.Equal(16, grid.Nodes.Count);
        Assert.Equal(2, grid.Nodes.Where(x => x.RiskFactor == 16).Count());
        Assert.Equal(2, grid.Nodes.Where(x => x.RiskFactor == 8).Count());
        Assert.Equal(2, grid.Nodes.Where(x => x.RiskFactor == 34).Count());
        Assert.Equal(2, grid.Nodes.Where(x => x.RiskFactor == 2).Count());
        Assert.Equal(1, grid.Nodes.Where(x => x.RiskFactor == 17).Count());
        Assert.Equal(1, grid.Nodes.Where(x => x.RiskFactor == 35).Count());
        Assert.Equal(1, grid.Nodes.Where(x => x.RiskFactor == 3).Count());
        Assert.Equal(1, grid.Nodes.Where(x => x.RiskFactor == 9).Count());
    }

    [Theory]
    [InlineData(10,5,50)]
    [InlineData(2,20,40)]
    public void IncreaseGridSize_CheckXSize(int currentSize, int times, int expectedResult)
    {
        var grid = new Grid
        {
            Nodes = new List<Node>
            {
                
            },
            XSize = currentSize
        };
        _service.IncreaseGridSize(grid, times);
        Assert.Equal(expectedResult, grid.XSize);
    }

    [Theory]
    [InlineData(2, 2, 4)]
    [InlineData(2, 20, 40)]
    public void IncreaseGridSize_CheckYSize(int currentSize, int times, int expectedResult)
    {
        var grid = new Grid
        {
            Nodes = new List<Node>
            {
                new()
                {
                    RiskFactor = 5,
                    X = 1,
                    Y = 1
                }
            },
            YSize = currentSize
        };
        _service.IncreaseGridSize(grid, times);
        Assert.Equal(expectedResult, grid.YSize);
    }
}