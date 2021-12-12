using Path = DayTwelve.Services.Path;

namespace DayTwelve.Interfaces;

public interface IPathFindingService
{
    List<Path> FindPaths(List<CaveConnections> caveConnections);
}