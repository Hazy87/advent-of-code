using System.Collections.Concurrent;
using Path = DayTwelve.Services.Path;

namespace DayTwelve.Interfaces;

public interface IPathFindingService
{
    ConcurrentBag<Path> FindPaths(List<CaveConnections> caveConnections);
}