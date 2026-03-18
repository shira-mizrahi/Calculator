using Calculator.CalculatorLibrary;

namespace Calculator.Parser.Parsers
{
    public interface IParser
    {
        IExpression? Parse(List<string> tokens);
    }
}
