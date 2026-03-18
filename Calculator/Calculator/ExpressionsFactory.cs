using Calculator.CalculatorLibrary;
using Calculator.CalculatorLibrary.BinaryOperations;

public class ExpressionsFactory
{
    private Dictionary<string, Func<IExpression>> _expressions;

    public ExpressionsFactory()
    {
        InitializeExpressions();
    }

    private void InitializeExpressions()
    {
        _expressions = new Dictionary<string, Func<IExpression>>()
        {
            ["+"] = () => new Add(),
            ["-"] = () => new Subtract(),
            ["*"] = () => new Multiply(),
            ["/"] = () => new Divide()
        };
    }

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