using DayFive.Domain;

namespace DayFive.Services;

public class CoordinateService : ICoordinateService
{
    public List<Coordinate> GetCoordinateListFromRange(Coordinate start, Coordinate end)
    {
        return GetCoordinateListFromRangeOrder(start, end);
    }

    public List<Coordinate> GetCoordinateListFromRangeOrder(Coordinate start, Coordinate end)
    {
        if (start.X < end.X)
            return GetCoordinateListFromRangeInternal(start, end);
        return GetCoordinateListFromRangeInternal(end, start);
    }
    public List<Coordinate> GetCoordinateListFromRangeInternal(Coordinate start, Coordinate end)
    {
        var returnList = new List<Coordinate>();
        var lowestY = start.Y > end.Y ? end.Y : start.Y;
        var highestY = start.Y < end.Y ? end.Y : start.Y;
        var lowestX = start.X > end.X ? end.X : start.X;
        var highestX = start.X < end.X ? end.X : start.X;
        if (start.X == end.X && start.Y != end.Y)
        {
            for (var i = lowestY; i <= highestY; i++)
            {
                returnList.Add(new Coordinate { X = start.X, Y = i });
            }
        }
        else if (start.Y == end.Y && start.X != end.X)
        {
            for (var i = lowestX; i <= highestX; i++)
            {
                returnList.Add(new Coordinate { X = i, Y = start.Y });
            }
        }
        else if (start.X == start.Y && end.Y == end.X)
        {
            for (var i = lowestX; i <= highestX; i++)
            {
                returnList.Add(new Coordinate { X = i, Y = i });
            }
        }
        else if (start.X < end.X && start.Y < end.Y)
        {
            var counter = 0;
            for (var i = start.Y; i <= end.Y; i++)
            {
                returnList.Add(new Coordinate { X = start.X + counter, Y = i });
                counter++;
            }
        }
        else
        {
            var counter = 0;
            for (var i = 0; i <= end.X - start.X; i++)
            {
                returnList.Add(new Coordinate { X = start.X + counter, Y =  start.Y -i });
                counter++;
            }
        }
        return returnList;
    }
}