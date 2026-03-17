using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Parser.Conventers
{
    public interface IInfixConverter
    {
        List<string> Convert(string infix);
    }
}
