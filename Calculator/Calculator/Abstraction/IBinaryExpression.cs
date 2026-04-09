namespace Calculator.CalculatorLibrary.Abstraction;
public interface IBinaryExpression : IExpression
{
    IExpression? Left { get; set; }
    IExpression? Right { get; set; }

}
