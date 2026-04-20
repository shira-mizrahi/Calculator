namespace Calculator.CalculatorLibrary.Abstraction
{
    public interface IUnaryExpression : IExpression
    {
        IExpression? Expression { get; set; }
    }
}
