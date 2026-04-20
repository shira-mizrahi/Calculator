using Calculator.CalculatorLibrary.Abstraction;

namespace Calculator.CalculatorLibrary.BinaryExpressions;

public class Add(IExpression? left = null, IExpression? right = null) : IBinaryExpression
{
    public IExpression? Left { get; set; } = left;
    public IExpression? Right { get; set; } = right;

    public double? Calculate()
    {
        return Left?.Calculate() + Right?.Calculate();
    }
}

