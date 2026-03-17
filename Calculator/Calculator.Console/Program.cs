using System;
using System.Collections.Generic;
using Calculator.Parser.Conventers;
using Calculator.Parser;
using Calculator.Parser.Parsers;

namespace Calculator.ConsoleUI
{
    class Program
    {
        static void Main()
        {
            var tokenizer = new Tokenizer();
            var converter = new InfixToPrefixConverter(tokenizer);
            var parser = new PrefixExpressionParser(new ExpressionsFactory());
            var tests = new List<string>
            {
                "3+4+5",
                "3+4*5",
                "(3+4)*5",
                "10-2-3",
                "8/(4-2)"
            };

            foreach (var expression in tests)
            {
                var result = converter.Convert(expression);
                var numericResult = parser.Parse(result);
                System.Console.WriteLine($"Infix: {expression}");
                System.Console.WriteLine($"Lisp : {string.Join(" ", result)}");
                System.Console.WriteLine($"result : {numericResult?.Calculate()}");
                System.Console.WriteLine();
            }
        }
    }
}