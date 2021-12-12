using System.Collections.Concurrent;

namespace DayTwelve.Services;

public class PathFindingService : IPathFindingService
{
    private ConcurrentBag<Path> paths = new();
    public ConcurrentBag<Path> FindPaths(List<CaveConnections> caveConnections)
    {
        Parallel.ForEach(caveConnections.Where(x => x.PointA == "start"), startingConnection =>
        {
            var path = StartPath(startingConnection);
            var tryTraversePath = Traverse(caveConnections.Where(x => x.PointA != "start").ToList(), startingConnection.PointB, path);
            if (tryTraversePath)
                paths.Add(path);
        });
        return paths;
    }

    private static Path StartPath(CaveConnections connection)
    {
        var path = new Path();
        path.Segments.Add("start");
        path.Segments.Add(connection.PointB);
        return path;
    }

    private bool Traverse(List<CaveConnections> caveConnections, string lastPoint, Path path)
    {
        var foundPath = false;
        //Find places to move which I didnt just come from.
        var possibleMoves = caveConnections.Where(x => x.PointA == lastPoint || x.PointB == lastPoint);
        
        foreach (var destination in possibleMoves)
        {
            if (TraversePossibleMove(caveConnections, lastPoint, path, destination))
                foundPath = true;
        }

        return foundPath;
    }

    private bool TraversePossibleMove(List<CaveConnections> caveConnections, string lastPoint, Path path, CaveConnections destination)
    {
        if (PathEnded(path)) return false;

        var newPath = ClonePath(path);
        var success = TryMoveToNextPoint(caveConnections, lastPoint, newPath, destination);
        if (!success || newPath.Segments.LastOrDefault() != "end") return false;
        
        paths.Add(newPath);
        return true;
    }

    private static Path ClonePath(Path path)
    {
        var newPath = new Path
        {
            Segments = new List<string>(path.Segments)
        };
        return newPath;
    }

    private static bool PathEnded(Path path)
    {
        return path.Segments.Contains("end");
    }

    private bool TryMoveToNextPoint(List<CaveConnections> caveConnections, string lastPoint, Path path, CaveConnections? destination)
    {
        var nextPoint = destination?.PointA == lastPoint ? destination.PointB : destination?.PointA;
        if (IsSmallCaveAndAlreadyVisited(nextPoint, path))
            return false;
        path.Segments.Add(nextPoint);
        Traverse(caveConnections, nextPoint, path);
        return true;
    }

    public bool IsSmallCaveAndAlreadyVisited(string destination, Path path)
    {
        return IsSmallCave(destination) && DontHaveTimeForaVisit(destination, path);
    }

    private static bool DontHaveTimeForaVisit(string destination, Path path)
    {
        var smallCaves = path.Segments.Where(x => x.ToUpper() != x).GroupBy(x => x);
        if (smallCaves.Any(x => x.Count() > 1) && path.Segments.Contains(destination))
            return true;
        return false;
    }

    private static bool IsSmallCave(string destination)
    {
        return destination.ToUpper() != destination && destination != "end";
    }
}