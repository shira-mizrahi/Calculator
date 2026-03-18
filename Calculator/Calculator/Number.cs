namespace Calculator.CalculatorLibrary
{
    public class Number(double? value = null) : IExpression
    {
        public double? Value { get; set; } = value;

        public double? Calculate()
        {
            return Value;
        }
    }
}
