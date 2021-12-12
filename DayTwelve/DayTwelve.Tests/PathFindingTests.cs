using System.Collections.Generic;
using DayTwelve.Services;
using Xunit;

namespace DayTwelve.Tests;

public class PathFindingTests
{
    private readonly PathFindingService _service;

    public PathFindingTests()
    {
        _service = new PathFindingService();
    }

    [Fact]
    public void FindCorrectNumberOfPaths()
    {
        var caveConnectionsList = new List<CaveConnections>(){new() {PointA = "start", PointB = "A"}, new() { PointA = "start", PointB = "B" } , new() { PointA = "A", PointB = "c" }, new() { PointA = "A", PointB = "b" } , new() { PointA = "A", PointB = "end" } , new() { PointA = "b", PointB = "end" } };
        var paths = _service.FindPaths(caveConnectionsList);
        Assert.Equal(10, paths.Count);
    }

    [Theory]
    [InlineData("start-YY-gp-YY-rz", "rz", false)]
    [InlineData("start-YY-gp-YY-rz-AA-ca-AAA-rz", "rz", true)]
    [InlineData("start-YY-gp-YY-rz-AA-ca-AAA-rz", "ca", true)]
    [InlineData("start-b-d-b-A", "c", false)]
    public void IsSmallCaveAndHaveTime(string pathString, string destination, bool expectedResult)
    {
        var path = new Path();
        foreach (var pathPart in pathString.Split("-"))
        {
            path.Segments.Add(pathPart);
        }

        var result = _service.IsSmallCaveAndAlreadyVisited(destination, path);
        Assert.Equal(expectedResult, result);
    }
}