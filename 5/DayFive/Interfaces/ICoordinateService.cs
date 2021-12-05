using DayFive.Domain;

namespace DayFive.Interfaces;

public interface ICoordinateService
{
    List<Coordinate> GetCoordinateListFromRange(Coordinate start, Coordinate end);
}
