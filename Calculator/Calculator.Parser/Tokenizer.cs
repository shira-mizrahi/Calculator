using System.Text.RegularExpressions;
namespace Calculator.Parser
{
    public class Tokenizer
    {
        public List<string> Tokenize(string input)
        {
            var tokens = new List<string>();
            var pattern = @"(\d+(\.\d+)?)|[+\-*/()]|\s+";
            var matches = Regex.Matches(input, pattern);
            int currentIndex = 0;
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
}
