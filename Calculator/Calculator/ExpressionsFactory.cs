
using Calculator.CalculatorLibrary.Abstraction;

namespace Calculator.CalculatorLibrary;
public class ExpressionsFactory(Dictionary<string, Func<IExpression>> expressions)
{
    private Dictionary<string, Func<IExpression>> _expressions = expressions;

    public IExpression GetExpressionByToken(string token)
    {
        if (double.TryParse(token, out var result))
        {
            return new Number(result);
        }

        if (_expressions.TryGetValue(token, out var expressionFactory))
        {
            return expressionFactory();
        }

        throw new ArgumentException($"Unknown token: {token}");
    }
}