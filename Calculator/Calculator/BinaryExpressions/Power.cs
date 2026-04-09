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
        return Math.Pow(Left?.Calculate() ?? 0, Right?.Calculate() ?? 0);
    }
}
