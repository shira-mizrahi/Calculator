using Calculator.CalculatorLibrary.Abstraction;

namespace Calculator.CalculatorLibrary;
public class Number(double? value = null) : IExpression
{
    private double? _value { get; set; } = value;

    public double? Calculate()
    {
        return _value;
    }
}
