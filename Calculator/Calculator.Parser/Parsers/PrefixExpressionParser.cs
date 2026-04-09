using Calculator.CalculatorLibrary;
using Calculator.CalculatorLibrary.Abstraction;
using Calculator.Parser.Abstract;

namespace Calculator.Parser.Parsers;

public class PrefixExpressionParser : IParser
{
    private delegate IExpression? ParseMethod(IExpression expression, List<string> tokens, ref int index);
    private ExpressionsFactory? _factory { get; set; }
    private Dictionary<Type, ParseMethod> _parseMethods;

    public PrefixExpressionParser(ExpressionsFactory? expressionsFactory)
    {
        _factory = expressionsFactory;
        _parseMethods = new Dictionary<Type, ParseMethod>
        {
            [typeof(IBinaryExpression)] = ParseBinary
        };
    }
    public IExpression? Parse(List<string> tokens)
    {
        var index = 0;
        return Parse(tokens, ref index);
    }
    private IExpression? Parse(List<string> tokens, ref int index)
    {
        if (index > tokens.Count)
            return null;


        var token = tokens[index];
        index++;
        var expression = _factory?.GetExpressionByToken(token);
        if (expression is Number)
            return expression;
        var key = _parseMethods.Keys.FirstOrDefault(t => t.IsAssignableFrom(expression?.GetType()));
        if (key != null)
            return _parseMethods[key](expression, tokens, ref index);
        else
            throw new ArgumentException($"Unknown expression type: {expression?.GetType()}");
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
