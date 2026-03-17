using Calculator.CalculatorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Parser.Parsers
{
    public interface IParser
    {
        IExpression? Parse(List<string> tokens);
    }
}
