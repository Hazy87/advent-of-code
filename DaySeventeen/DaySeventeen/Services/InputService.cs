using DaySeventeen.Interfaces;

namespace DaySeventeen.Services;

public class InputService :IInputService
{
    public Input GetLines(bool example = false)
    {
        if (example)
            return new Input { MaxX = 30, MinX = 20, MaxY = -10, MinY = -5};
        return new Input { MaxX = 263, MinX = 207, MaxY = -63, MinY = -115 };
    }
    
}

public class Input
{
    public int MaxX { get; set; }
    public int MinX { get; set; }
    public int MaxY { get; set; }
    public int MinY { get; set; }
}