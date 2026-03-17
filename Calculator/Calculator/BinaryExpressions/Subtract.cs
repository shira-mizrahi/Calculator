using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.CalculatorLibrary.BinaryOperations
{
    public class Subtract : IBinaryExpression
    {
        public Subtract(IExpression? left=null, IExpression? right=null)
        {
            Left = left;
            Right = right;
        }

        public IExpression? Left { get; set; }
        public IExpression? Right { get; set; }

        public double? Calculate()
        {
            return  Left?.Calculate() - Right?.Calculate();
        }
    }
}
