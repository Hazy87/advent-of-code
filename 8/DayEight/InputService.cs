public class InputService :IInputService
{
    public async Task<IEnumerable<Input>> GetInput()
    {
        var lines = await File.ReadAllLinesAsync("input.txt");
        var output = new List<Input>();
        foreach (var line in lines)
        {
            var signals = line.Split("|")[0].Split(" ").ToList();
            var digitalOutputs = line.Split("|")[1].Split(" ").ToList();
            
            output.Add(new Input()
            {
                SignalPatternsList = signals,
                DigitalOutputsList = digitalOutputs
            });
        }

        return output;
    }
}