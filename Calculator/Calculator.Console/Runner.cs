using Calculator.ConsoleUI.Readers;
using Calculator.ConsoleUI.Writers;
using Calculator.Parser;

namespace Calculator.ConsoleUI
{
    public class Runner
    {
        public Runner(ExpressionProcessor? expressionProcessor, IReader reader, IWriter writer)
        {
            ExpressionProcessor = expressionProcessor;
            Reader = reader;
            Writer = writer;
        }

        public ExpressionProcessor? ExpressionProcessor { get; set; }
        public IReader Reader { get; set; }
        public IWriter Writer { get; set; }

        public void Run()
        {
            Writer.Write("Enter an expression to calculate:");
            Writer.Write("Type 'exit' to quit.");
            while (true)
            {
                Writer.Write("> ");
                var input = Reader.Read();
                if (string.Equals(input, "exit"))
                    break;
                if (string.IsNullOrWhiteSpace(input))
                    continue;
                try
                {
                    var expression = ExpressionProcessor?.GetExpression(input);

                    if (expression == null)
                    {
                        Writer.Write("Invalid expression.");
                        continue;
                    }
                    var result = expression.Calculate();
                    Writer.Write($"{input} = {result}");
                }
                catch (Exception ex)
                {
                    Writer.Write($"Error: {ex.Message}");
                }
            }
        }
    }
}