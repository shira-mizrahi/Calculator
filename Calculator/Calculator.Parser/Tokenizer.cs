using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Calculator.Parser
{
    public  class Tokenizer
    {
        public static List<string> Tokenize(string input)
        {
            var tokens = new List<string>();

            var pattern = @"(\d+(\.\d+)?)|[+\-*/()]";
            foreach (Match match in Regex.Matches(input, pattern))
            {
                tokens.Add(match.Value);
            }

            return tokens;
        }
       
    }
}
