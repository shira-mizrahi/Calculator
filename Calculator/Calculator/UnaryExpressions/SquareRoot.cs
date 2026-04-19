using Calculator.CalculatorLibrary.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.CalculatorLibrary.UnaryExpressions
{
    public class SquareRoot : IUnaryExpression
    {
        public IExpression? expression { get; set ; }

        public double? Calculate()
        {
            return Math.Sqrt(expression?.Calculate() ?? 0);
        }
    }
}
