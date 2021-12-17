namespace DaySeventeen.Interfaces;

public interface IProbePlottingService
{
    bool IsIntrench(Input input, int x, int y);
    bool HasOverShotTrench(Input input, int x, int y);
    (int xPosition, int yPosition, int xVelocity, int yVelocity) PlotStep(int currentXPosition, int currentYPosition, int xVelocity, int yVelocity);
    int? HighestPoint(int xVelocity, int yVelocity, Input input);
}