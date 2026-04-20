using Calculator.CalculatorLibrary.Abstraction;

namespace Calculator.CalculatorLibrary.UnaryExpressions;

public class SquareRoot(IExpression? expression = null) : IUnaryExpression
{
    public IExpression? Expression { get; set; } = expression;

    public double? Calculate()
    {
        var value = Expression?.Calculate()
      ?? throw new InvalidOperationException("Missing operand");

        if (value < 0)
            throw new InvalidOperationException("Square root of negative number is not defined");

        return Math.Sqrt(value);
    }
}
