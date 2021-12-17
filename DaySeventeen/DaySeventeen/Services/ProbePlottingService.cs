using System.Reflection.Metadata.Ecma335;

namespace DaySeventeen.Services;

public class ProbePlottingService : IProbePlottingService
{
    public (int xPosition, int yPosition, int xVelocity, int yVelocity) PlotStep(int currentXPosition, int currentYPosition, int xVelocity, int yVelocity)
    {
        var newXPosition = currentXPosition + xVelocity;
        var newYPosition = currentYPosition + yVelocity;
        var newXvelocity = xVelocity <= 0 ? xVelocity == 0 ? 0 : xVelocity + 1 : xVelocity - 1;
        var newYVelocity = yVelocity-1;
        return (newXPosition, newYPosition, newXvelocity, newYVelocity);
    }

    public bool IsIntrench(Input input, int x, int y)
    {
        if (input.MaxY >= y && y >= input.MinY && input.MaxX >= x && x >= input.MinX)
            return true;
        return false;
    }

    public bool HasOverShotTrench(Input input, int x, int y)
    {
        if (x > input.MaxX || y <  input.MinY)
            return true;
        return false;

    }
    public bool SuccessFulShot(int xVelocity, int yVelocity, Input input)
    {
        var highestPointThisRun = 0;
        var currentXvelocity = xVelocity;
        var currentYVelocity = yVelocity;
        var currentX = 0;
        var currentY = 0;
        while (!HasOverShotTrench(input, currentX, currentY))
        {
            //Console.WriteLine($"X : {currentX}, Y : {currentY}");
            if (IsIntrench(input, currentX, currentY))
            {
                return true;
            }

            var (newXPosition, newYPosition, newXVelocity, newYVelocity) =
                PlotStep(currentX, currentY, currentXvelocity, currentYVelocity);
            if (newYPosition > highestPointThisRun)
                highestPointThisRun = newYPosition;
            currentY = newYPosition;
            currentX = newXPosition;
            currentYVelocity = newYVelocity;
            currentXvelocity = newXVelocity;
        }

        return false;
    }
    public int? HighestPoint(int xVelocity, int yVelocity, Input input)
    {
        int? highestPoint = null;
        int currentX;
        int currentY;
        var highestPointThisRun = 0;
        var currentXvelocity = xVelocity;
        var currentYVelocity = yVelocity;
        currentX = 0;
        currentY = 0;
        while (!HasOverShotTrench(input, currentX, currentY))
        {
            //Console.WriteLine($"X : {currentX}, Y : {currentY}");
            if (IsIntrench(input, currentX, currentY))
            {
                //Console.WriteLine($"X : {xVelocity}, Y : {yVelocity}");
                if (highestPoint == null)
                    highestPoint = highestPointThisRun;
                if (highestPointThisRun > highestPoint)
                    highestPoint = highestPointThisRun;
                break;
            }

            var (newXPosition, newYPosition, newXVelocity, newYVelocity) =
                PlotStep(currentX, currentY, currentXvelocity, currentYVelocity);
            if (newYPosition > highestPointThisRun)
                highestPointThisRun = newYPosition;
            currentY = newYPosition;
            currentX = newXPosition;
            currentYVelocity = newYVelocity;
            currentXvelocity = newXVelocity;
        }

        return highestPoint;
    }
}