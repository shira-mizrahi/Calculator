using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.CalculatorLibrary.BinaryOperations
{
    public interface IBinaryExpression:IExpression
    {
        IExpression? Left { get; set; } 
        IExpression? Right { get; set; }

    }
}
