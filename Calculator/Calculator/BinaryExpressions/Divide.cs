//CR: Clean Code: wrong namespace
namespace Calculator.CalculatorLibrary.BinaryOperations
{
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
            //CR: Clean Code: use var
            double? rightResult = Right?.Calculate();
            if (rightResult == 0)
                throw new DivideByZeroException();
            return Left?.Calculate() / rightResult;
        }
    }
}
