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
            Traverse(caveConnections.Where(x => x.PointA != "start").ToList(), connection.PointB, path);
            paths.Add(path);
        }

        var list = paths.Where(x => x.Segments.LastOrDefault() == "end").ToList(); 
        PrintBoard(list);

        list = list.Where(x => x.Segments.Where(a => a.ToUpper() != a).GroupBy(y => y).Count(z => z.Count() > 1) <= 1).ToList();
        return list;
    }
    private static void PrintBoard(List<Path> Paths)
    {
        foreach (var pathGroup in Paths)
        {
            Console.WriteLine(string.Join("-", pathGroup.Segments));

        }
        Console.WriteLine($"");
        Console.WriteLine($"");

    }
    private void Traverse(List<CaveConnections> caveConnections, string lastPoint, Path path)
    {
        var possibleMoves = caveConnections.Where(x => x.PointA == lastPoint || x.PointB == lastPoint);
        if (possibleMoves.Count() == 1)
        {
            var firstOrDefault = possibleMoves.FirstOrDefault();
            NewMethod(caveConnections, lastPoint, path, firstOrDefault);
        }

        if (possibleMoves.Count() == 0 && path.Segments.LastOrDefault() != "end")
        {
            paths.Remove(path);
        }
        foreach (var destination in possibleMoves)
        {
            var newPath = new Path();
            newPath.Segments = new List<string>(path.Segments);
            if (!PathEnded(newPath))
            {
                var success = NewMethod(caveConnections, lastPoint, newPath, destination);
                if(success) 
                    paths.Add(newPath);
            }
        }
    }

    private bool PathEnded(Path path)
    {
        return path.Segments.Contains("end");
    }

    private bool NewMethod(List<CaveConnections> caveConnections, string lastPoint, Path path, CaveConnections? desintation)
    {
        var nextPoint = desintation.PointA == lastPoint ? desintation.PointB : desintation.PointA;
        if (IsSmallCaveAndAlreadyVisited(nextPoint, path))
            return false;
        if(path.Segments.LastOrDefault() == nextPoint)
            return false;
        path.Segments.Add(nextPoint);
         Traverse(caveConnections, nextPoint, path);
         return true;
    }

    public bool IsSmallCaveAndAlreadyVisited(string destination, Path path)
    {
        if(string.Join("-", path.Segments).StartsWith("start-b-d-b-A"))
            Debugger.Break();
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