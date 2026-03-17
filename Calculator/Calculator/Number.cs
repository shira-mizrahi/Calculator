using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.CalculatorLibrary
{
    public class Number(double? value=null) : IExpression
    {
        public double? Value { get; set; } = value;

        public double? Calculate()
        {
            return Value;
        }
    }
}
