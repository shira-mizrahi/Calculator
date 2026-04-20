using Calculator.ConsoleUI.Abstraction;
using Calculator.Parser;

namespace Calculator.ConsoleUI;

public class Runner(ExpressionProcessor? expressionProcessor, IReader reader, IWriter writer)
{
    private ExpressionProcessor? _expressionProcessor { get; set; } = expressionProcessor;
    private IReader _reader { get; set; } = reader;
    private IWriter _writer { get; set; } = writer;

    public void Run()
    {
        _writer.Write("Enter an expression to calculate:");
        _writer.Write("Type 'exit' to quit.");
        while (true)
        {
            _writer.Write("> ");
            var input = _reader.Read();
            if (string.Equals(input, "exit"))
                break;
            if (string.IsNullOrWhiteSpace(input))
                continue;
            try
            {
              
                var expression = _expressionProcessor?.GetExpression(input);

                if (expression == null)
                {
                    _writer.Write("Invalid expression.");
                    continue;
                }
                var result = expression.Calculate();
                _writer.Write($"{input} = {result}");
            }
            catch (Exception ex)
            {
                _writer.Write($"Error: {ex.Message}");
            }
        }
    }
}