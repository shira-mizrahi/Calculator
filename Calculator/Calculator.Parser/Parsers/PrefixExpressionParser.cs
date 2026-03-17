using Calculator.CalculatorLibrary;
using Calculator.CalculatorLibrary.BinaryOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Parser.Parsers
{
    public class PrefixExpressionParser : IParser
    {
        public delegate IExpression? ParseMethod(IExpression expression, List<string> tokens, ref int index);
        public ExpressionsFactory? Factory { get; set; }
        private Dictionary<Type, ParseMethod> _parseMethods;

        public PrefixExpressionParser(ExpressionsFactory? expressionsFactory)
        {
            Factory = expressionsFactory;
            InitializeParseMethods();
        }

        private void InitializeParseMethods()
        {
            _parseMethods = new Dictionary<Type, ParseMethod>
            {
                [typeof(Add)] = ParseBinary,
                [typeof(Subtract)] = ParseBinary,
                [typeof(Multiply)] = ParseBinary,
                [typeof(Divide)] = ParseBinary,


            };
        }
        public IExpression? Parse(List<string> tokens)
        {
            int index= 0;
            return Parse(tokens, ref index);
        }
        private IExpression? Parse(List<string> tokens, ref int index)
        {
            if (index > tokens.Count)
                return null;
            string token = tokens[index];
            index++;
            var expression = Factory?.GetExpressionByToken(token);
            if (expression is Number)
                return expression;
            else
                if (_parseMethods.TryGetValue(key: expression.GetType(), out ParseMethod? parseMethod))
            {
                return parseMethod(expression, tokens, ref index);
            }

            throw new ArgumentException($"Unknown expression type: {expression.GetType()}");
        }
        private IExpression? ParseBinary(IExpression binaryExpression, List<string> tokens, ref int index)
        {
            var left = Parse(tokens, ref index);
            var right = Parse(tokens, ref index);
            if (left != null && right != null)
            {
                ((IBinaryExpression)binaryExpression).Left = left;
                ((IBinaryExpression)binaryExpression).Right = right;
                return binaryExpression;
            }
            return null;
        }

       
    }
}
