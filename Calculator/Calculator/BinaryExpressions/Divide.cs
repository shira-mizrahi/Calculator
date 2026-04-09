using Calculator.CalculatorLibrary.Abstraction;

namespace Calculator.CalculatorLibrary.BinaryExpressions;
public class Divide : IBinaryExpression
{
    public Divide(IExpression? left = null, IExpression? right = null)
    {
        Left = left;
        Right = right;
    }

    public IExpression? Left { get; set; }
    public IExpression? Right { get; set; }

    public double? Calculate()
    {
        var rightResult = Right?.Calculate();
        if (rightResult == 0)
            throw new DivideByZeroException();
        return Left?.Calculate() / rightResult;
    }
}
