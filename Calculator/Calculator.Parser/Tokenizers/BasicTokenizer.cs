using Calculator.Parser.Abstract;
using System.Text.RegularExpressions;
namespace Calculator.Parser.Tokenizers;

public class BasicTokenizer : ITokenizer
{
    public List<string> Tokenize(string input)
    {
        var tokens = new List<string>();
        var pattern = @"(\d+(\.\d+)?)|[+\-*^/()]|\s+";
        var matches = Regex.Matches(input, pattern);
        var currentIndex = 0;
        foreach (Match match in matches)
        {
            if (match.Index != currentIndex)
            {
                throw new FormatException($"Invalid character at position {currentIndex}");
            }
            if (!string.IsNullOrWhiteSpace(match.Value))
            {
                tokens.Add(match.Value);
            }
            currentIndex += match.Length;
        }
        if (currentIndex != input.Length)
        {
            throw new FormatException($"Invalid character at position {currentIndex}");
        }
        return tokens;
    }
}
