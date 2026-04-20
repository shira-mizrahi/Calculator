using Calculator.Parser.Abstract;
using System.Text.RegularExpressions;

namespace Calculator.Parser.Tokenizers
{
    public class SupportUnaryTokenizer : ITokenizer
    {
        public List<string> Tokenize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new List<string>();
            var tokens = new List<string>();
            var pattern = @"sqrt|\d+(\.\d+)?|[+\-*^!/()]";
            var lowerInput = input.ToLower();
            var matches = Regex.Matches(lowerInput, pattern);
            foreach (Match match in matches)
            {
                var token = match.Value;

                if (token == "sqrt")
                    token = "√";

                tokens.Add(token);
            }
            var cleanInput = Regex.Replace(lowerInput, @"\s+", "")
                                  .Replace("sqrt", "√");
            var rebuilt = string.Concat(tokens);
            if (rebuilt != cleanInput)
            {
                throw new FormatException("Invalid character in input");
            }
            return tokens;
        }
    }
}
