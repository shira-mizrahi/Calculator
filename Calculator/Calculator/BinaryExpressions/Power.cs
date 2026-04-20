using Calculator.CalculatorLibrary.Abstraction;

namespace Calculator.CalculatorLibrary.BinaryExpressions;
public class Power(IExpression? left = null, IExpression? right = null) : IBinaryExpression
{
    public IExpression? Left { get; set; } = left;
    public IExpression? Right { get; set; } = right;

    public double? Calculate()
    {
        if (Left?.Calculate() is double l && Right?.Calculate() is double r)
        {
            return Math.Pow(l, r);
        }

        throw new InvalidOperationException("Invalid operands for power");
    }
}
