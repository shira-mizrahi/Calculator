//CR: Clean Code: wrong namespace
namespace Calculator.CalculatorLibrary.BinaryOperations
{
    public interface IBinaryExpression : IExpression
    {
        IExpression? Left { get; set; }
        IExpression? Right { get; set; }

    }
}
