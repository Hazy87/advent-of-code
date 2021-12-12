namespace DayTwelve.Services;

public class PathFindingService : IPathFindingService
{
    private List<Path> paths = new();
    public List<Path> FindPaths(List<CaveConnections> caveConnections)
    {
        foreach (var connection in caveConnections.Where(x => x.PointA == "start"))
        {
            var path = new Path();
            path.Segments.Add("start");
            path.Segments.Add(connection.PointB);
            if(Traverse(caveConnections.Where(x => x.PointA != "start").ToList(), connection.PointB, path))
                paths.Add(path);
        }
        return paths;
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
        var newPath = new Path();
        newPath.Segments = new List<string>(path.Segments);
        if (!PathEnded(newPath))
        {
            var success = TryMoveToNextPoint(caveConnections, lastPoint, newPath, destination);
            if (success && newPath.Segments.LastOrDefault() == "end")
            {
                paths.Add(newPath);
                return true;
            }
        }
        return false;
    }

    private bool PathEnded(Path path)
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
        if (IsSmallCave(destination) && DontHaveTimeForaVisit(destination, path))
            return true;
        return false;
    }

    private bool DontHaveTimeForaVisit(string destination, Path path)
    {
        var smallCaves = path.Segments.Where(x => x.ToUpper() != x).GroupBy(x => x);
        if (smallCaves.Any(x => x.Count() > 1) && path.Segments.Contains(destination))
            return true;
        return false;
    }

    private bool IsSmallCave(string destination)
    {
        if (destination.ToUpper() != destination && destination != "end")
            return true;
        return false;
    }
}