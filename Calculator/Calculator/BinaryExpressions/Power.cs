using Calculator.CalculatorLibrary.Abstraction;

namespace Calculator.CalculatorLibrary.BinaryExpressions;
public class Power : IBinaryExpression
{
    public Power(IExpression? left = null, IExpression? right = null)
    {
        Left = left;
        Right = right;
    }

    public IExpression? Left { get; set; }
    public IExpression? Right { get; set; }

    public double? Calculate()
    {
        if (Left?.Calculate() is double l && Right?.Calculate() is double r)
        {
            return Math.Pow(l, r);
        }

        throw new InvalidOperationException("Invalid operands for power");
    }
}
