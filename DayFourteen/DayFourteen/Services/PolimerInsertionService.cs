namespace DayFourteen.Services;

public class PolimerInsertionService : IPolimerInsertionService
{
    public string InsertPolimer(string template, List<(string input, string output)> rules)
    {
        var startingString = "";
        for (int i = 0; i < template.Length; i++)
        {
            if (i == template.Length - 1)
            {
                startingString += template[i];
                continue;
            }

            var s = template[i] + template[i + 1].ToString();
            if (rules.Any(x => x.input == s))
            {
                startingString += template[i] + rules.First(x => x.input == s).output;
            }
            else
            {
                startingString += template[i];
            }
        }
        /*foreach (var valueTuple in rules)
        {
            startingString = startingString.Replace(valueTuple.input, valueTuple.output);
        }*/

        return startingString;
    }
}