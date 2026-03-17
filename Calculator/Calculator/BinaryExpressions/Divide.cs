using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.CalculatorLibrary.BinaryOperations
{
    public class Divide : IBinaryExpression
    {
        public Divide(IExpression? left=null, IExpression? right=null)
        {
            Left = left;
            Right = right;
        }

        public IExpression? Left { get; set; }
        public IExpression? Right { get; set; }

        public double? Calculate()
        {
            double? rightResult = Right?.Calculate();
            if (rightResult == 0)
                throw new DivideByZeroException();
            return Left?.Calculate() / rightResult;
        }
    }
}
