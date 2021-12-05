namespace DayFive.Services;

public class CoordinateService : ICoordinateService
{
    public List<Coordinate> GetCoordinateListFromRange(Coordinate start, Coordinate end)
    {
        var returnList = new List<Coordinate>();
        if (start.X == end.X)
        {
            var lowestY = start.Y > end.Y ? end.Y : start.Y;
            var highestY = start.Y < end.Y ? end.Y : start.Y;
            for (int i = lowestY; i <= highestY; i++)
            {
                returnList.Add(new Coordinate { X = start.X, Y = i });
            }
        }
        else
        {
            if (start.Y == end.Y)
            {
                var lowestX = start.X > end.X ? end.X : start.X;
                var highestX = start.X < end.X ? end.X : start.X;
                for (int i = lowestX; i <= highestX; i++)
                {
                    returnList.Add(new Coordinate { X = i, Y = start.Y });
                }
            }
        }
        return returnList;
    }
}