using Calculator.CalculatorLibrary.Abstraction;

namespace Calculator.Parser.Abstract;

public interface IParser
{
    IExpression? Parse(List<string> tokens);
}
