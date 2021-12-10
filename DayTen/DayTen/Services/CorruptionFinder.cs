namespace DayTen.Services;

public class CorruptionFinder : ICorruptionFinder
{
    public string GetAutocompletedString(string line)
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
                list.RemoveAt(openingChars.Length - 1);
                openingChars = list.ToArray();
                continue;
            }
        }

        var returnLine = "";
        foreach (var openingChar in openingChars.Reverse())
        {
            returnLine += getClosingChar(openingChar);
        }

        return returnLine;
    }

    private char getClosingChar(char openingChar)
    {
        switch (openingChar)
        {
            case '{':
                return '}';
            case '[':
                return ']';
            case '<':
                return '>';
            case '(':
                return ')';
            default:
                throw new Exception("Shouldnt get here");
        }
    }

    public bool IsCorruptLine(string line)
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
                list.RemoveAt(openingChars.Length - 1);
                openingChars = list.ToArray();
                continue;
            }

            return true;
        }

        return false;
    }

    public Int64 GetAutoCompletedScore(string completedLine)
    {
        Int64 score = 0;
        foreach (var c in completedLine.ToCharArray())
        {
            score = score * 5;
            var autoCompleteScore = GetAutoCompleteScoreFromChar(c);
            score += autoCompleteScore;
        }

        return score;
    }

    public int GetAutoCompleteScoreFromChar(char closingChar)
    {
        switch (closingChar)
        {
            case '}':
                return 3;
            case ']':
                return 2;
            case '>':
                return 4;
            case ')':
                return 1;
            default:
                throw new Exception("Shouldnt get here");
        }
    }

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