namespace DayTen.Services;

public class CorruptionFinder : ICorruptionFinder
{
    
    public char? FindFirstWrongCharacter(string line)
    {
        var chars = line.ToCharArray();
        var openingChars = Array.Empty<char>();
        foreach (var c in chars)
        {
            if (IsOpeningChar(c))
            {
                openingChars = openingChars.Append(c).ToArray();
                continue;
            }

            if (MatchingClosingChar(openingChars.Last(), c))
            {
                var list = openingChars.ToList();
                list.RemoveAt(openingChars.Length-1);
                openingChars = list.ToArray();
                continue;
            }

            return c;
        }

        return null;
    }

    private bool MatchingClosingChar(char opening, char closing)
    {
        if (opening == '{' && closing == '}')
            return true;
        if (opening == '<' && closing == '>')
            return true;
        if (opening == '[' && closing == ']')
            return true;
        if (opening == '(' && closing == ')')
            return true;
        return false;
    }

    private bool IsOpeningChar(char c)
    {
        if (c == '{' || c == '[' || c == '(' || c == '<')
            return true;
        return false;
    }
}