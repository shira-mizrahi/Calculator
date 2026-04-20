using Calculator.CalculatorLibrary.Abstraction;

namespace Calculator.CalculatorLibrary.BinaryExpressions;
public class Divide(IExpression? left = null, IExpression? right = null) : IBinaryExpression
{
    public IExpression? Left { get; set; } = left;
    public IExpression? Right { get; set; } = right;

    public double? Calculate()
    {
        var rightResult = Right?.Calculate();
        if (rightResult == 0)
            throw new DivideByZeroException();
        return Left?.Calculate() / rightResult;
    }
}
