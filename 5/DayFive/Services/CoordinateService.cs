namespace DayFive.Services;

public class CoordinateService : ICoordinateService
{
    public List<Coordinate> GetCoordinateListFromRange(Coordinate start, Coordinate end)
    {
        var returnList = new List<Coordinate>();
        if (start.X == end.X && start.Y != end.Y)
        {
            var lowestY = start.Y > end.Y ? end.Y : start.Y;
            var highestY = start.Y < end.Y ? end.Y : start.Y;
            for (int i = lowestY; i <= highestY; i++)
            {
                returnList.Add(new Coordinate { X = start.X, Y = i });
            }
        }
        else if (start.Y == end.Y && start.X != end.X)
        {
            var lowestX = start.X > end.X ? end.X : start.X;
            var highestX = start.X < end.X ? end.X : start.X;
            for (int i = lowestX; i <= highestX; i++)
            {
                returnList.Add(new Coordinate { X = i, Y = start.Y });
            }    
        }
        else if(start.X == start.Y && end.Y == end.X)
        {
            var lowestX = start.X > end.X ? end.X : start.X;
            var highestX = start.X < end.X ? end.X : start.X;
            for (int i = lowestX; i <= highestX; i++)
            {
                returnList.Add(new Coordinate { X = i, Y = i });
            }
        }
        else if (start.X > end.X && start.Y > end.Y)
        {
            var counter = 0;
            for (int i = start.X; i >= end.X; i--)
            {
                returnList.Add(new Coordinate { X = i, Y = start.Y - counter });
                counter++;
            }
        }

        else if (start.X < end.X && start.Y < end.Y)
        {
            var counter = 0;
            for (int i = start.Y; i <= end.Y; i++)
            {
                returnList.Add(new Coordinate { X = start.X + counter, Y = i});
                counter++;
            }
        }
        else
        {
            var lowestX = start.X > end.X ? end.X : start.X;
            var highestX = start.X < end.X ? end.X : start.X;
            var counter = 0;
            for (int i = lowestX; i <= highestX; i++)
            {
               returnList.Add(new Coordinate { X = i, Y =  end.Y - counter});
               counter++;
            }
        }
        return returnList;
    }
}