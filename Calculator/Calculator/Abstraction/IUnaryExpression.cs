using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.CalculatorLibrary.Abstraction
{
    public interface IUnaryExpression : IExpression
    {
        IExpression? expression { get; set; }
    }
}
