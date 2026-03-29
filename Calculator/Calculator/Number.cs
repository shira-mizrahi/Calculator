namespace Calculator.CalculatorLibrary
{
    public class Number(double? value = null) : IExpression
    {
        // CR: Clean Code: fields that are not used outside a class should be declared as private
        public double? Value { get; set; } = value;

        public double? Calculate()
        {
            return Value;
        }
    }
}
