//CR: Clean Code: wrong namespace 
namespace Calculator.CalculatorLibrary.BinaryOperations
{
    public class Add : IBinaryExpression
    {
        public Add(IExpression? left = null, IExpression? right = null)
        {
            Left = left;
            Right = right;
        }

        public IExpression? Left { get; set; }
        public IExpression? Right { get; set; }

        public double? Calculate()
        {
            return Left?.Calculate() + Right?.Calculate();
        }
    }
}
