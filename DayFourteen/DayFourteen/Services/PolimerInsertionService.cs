using System.Collections;
using System.Text;

namespace DayFourteen.Services;

public class PolimerInsertionService : IPolimerInsertionService
{
    public string InsertPolimer(string template, Hashtable rules)
    {
        StringBuilder startingString = new StringBuilder();
        Parallel.For(0, template.Length, new ParallelOptions{MaxDegreeOfParallelism = 1}, i =>
        {
            startingString.Append(template[i]);
            if (i == template.Length - 1)
            {
                return;
            }

            var s = template[i] + template[i + 1].ToString();
            if (rules.ContainsKey(s))
            {
                startingString.Append(rules[s]);
            }
        });
        /*
        for (int i = 0; i < template.Length; i++)
        {
            startingString.Append(template[i]);
            if (i == template.Length - 1)
            {
                continue;
            }

            var s = template[i] + template[i + 1].ToString();
            if (rules.ContainsKey(s))
            {
                startingString.Append(rules[s]);
            }
        }*/
        /*foreach (var valueTuple in rules)
        {
            startingString = startingString.Replace(valueTuple.input, valueTuple.output);
        }*/

        return startingString.ToString();
    }

    public string InsertPolimerReverse(string template, Hashtable rules)
    {
      /*  foreach (DictionaryEntry rule in rules)
        {
            for (int i = 0; i < template.Length; i++)
            {
                if(template[i] + template[i + 1].ToString() == rule.Value)

                var nextIndex = template.IndexOf(rule.Value);
            }
                
        }*/
        StringBuilder startingString = new StringBuilder();
        for (int i = 0; i < template.Length; i++)
        {
            startingString.Append(template[i]);
            if (i == template.Length - 1)
            {
                continue;
            }

            var s = template[i] + template[i + 1].ToString();
            if (rules.ContainsKey(s))
            {
                startingString.Append(rules[s]);
            }
        }
        /*foreach (var valueTuple in rules)
        {
            startingString = startingString.Replace(valueTuple.input, valueTuple.output);
        }*/

        return startingString.ToString();
    }
}