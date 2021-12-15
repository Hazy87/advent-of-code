using System.Collections.Generic;
using System.Linq;
using DayFifteen.Services;
using Xunit;

namespace DayFifteen.Tests;

public class DijkstraServiceTests
{
    private readonly DijkstraService _service;

    public DijkstraServiceTests()
    {
        _service = new DijkstraService();
    }

    [Fact]
    public void ConsiderNode_Should_ChangeCurrentNodeToVisited()
    {
        var neighbours = new List<Node>();
        neighbours.Add(new Node() { Distance = 0, RiskFactor = 1, Visited = false, X = 0, Y = 0 });
        neighbours.Add(new Node() { Distance = 0, RiskFactor = 1, Visited = false, X = 0, Y = 0 });
        neighbours.Add(new Node() { Distance = 0, RiskFactor = 1, Visited = false, X = 0, Y = 0 });
        var currentNode = new Node(){Distance = 0, RiskFactor = 1, Visited = false, X = 0, Y =0};
        _service.ConsiderNode(currentNode, neighbours);

        Assert.True(currentNode.Visited);
    }

    [Fact]
    public void ConsiderNode_Should_ChangeNeighboursFromMaxValue_ToCorrectValue()
    {
        var neighbours = new List<Node>();
        neighbours.Add(new Node() { Distance = int.MaxValue, RiskFactor = 2, Visited = false, X = 0, Y = 0 });
        neighbours.Add(new Node() { Distance = int.MaxValue, RiskFactor = 6, Visited = false, X = 0, Y = 0 });
        neighbours.Add(new Node() { Distance = int.MaxValue, RiskFactor = 4, Visited = false, X = 0, Y = 0 });
        _service.ConsiderNode(new Node() { Distance = 13, RiskFactor = 1, Visited = false, X = 0, Y = 0 }, neighbours);

        Assert.Equal(1, neighbours.Where(x => x.Distance == 15).Count());
        Assert.Equal(1, neighbours.Where(x => x.Distance == 19).Count());
        Assert.Equal(1, neighbours.Where(x => x.Distance == 17).Count());
    }

    [Fact]
    public void ConsiderNode_Should_ChangeNeighboursFromLargerValue_ToCorrectValue()
    {
        var neighbours = new List<Node>();
        neighbours.Add(new Node() { Distance = 22, RiskFactor = 2, Visited = false, X = 0, Y = 0 });
        neighbours.Add(new Node() { Distance = 55, RiskFactor = 6, Visited = false, X = 0, Y = 0 });
        neighbours.Add(new Node() { Distance = 667, RiskFactor = 4, Visited = false, X = 0, Y = 0 });
        _service.ConsiderNode(new Node() { Distance = 13, RiskFactor = 1, Visited = false, X = 0, Y = 0 }, neighbours);

        Assert.Equal(1, neighbours.Where(x => x.Distance == 15).Count());
        Assert.Equal(1, neighbours.Where(x => x.Distance == 19).Count());
        Assert.Equal(1, neighbours.Where(x => x.Distance == 17).Count());
    }

    [Fact]
    public void ConsiderNode_ShouldNot_ChangeNeighboursFromLargerValue_ToCorrectValue()
    {
        var neighbours = new List<Node>();
        neighbours.Add(new Node() { Distance = 2, RiskFactor = 2, Visited = false, X = 0, Y = 0 });
        neighbours.Add(new Node() { Distance = 5, RiskFactor = 6, Visited = false, X = 0, Y = 0 });
        neighbours.Add(new Node() { Distance = 6, RiskFactor = 4, Visited = false, X = 0, Y = 0 });
        _service.ConsiderNode(new Node() { Distance = 13, RiskFactor = 1, Visited = false, X = 0, Y = 0 }, neighbours);

        Assert.Equal(1, neighbours.Where(x => x.Distance == 2).Count());
        Assert.Equal(1, neighbours.Where(x => x.Distance == 5).Count());
        Assert.Equal(1, neighbours.Where(x => x.Distance == 6).Count());
    }
}