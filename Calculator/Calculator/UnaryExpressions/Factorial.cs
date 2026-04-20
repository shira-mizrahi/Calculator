
using Calculator.CalculatorLibrary.Abstraction;
using MathNet.Numerics;

namespace Calculator.CalculatorLibrary.UnaryExpressions;
public class Factorial(IExpression? expression = null) : IUnaryExpression
{
    public IExpression? Expression { get; set; } = expression;


    public double? Calculate()
    {
        var value = Expression?.Calculate();
        if (value < 0)
            throw new InvalidOperationException("Factorial of negative number");
        if (value is null)
            throw new InvalidOperationException();
        return Math.Round( SpecialFunctions.Gamma(value.Value + 1),10);
    }
}