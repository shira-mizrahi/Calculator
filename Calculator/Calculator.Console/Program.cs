using Calculator.Bootstrapper;
using Calculator.ConsoleUI.Readers;
using Calculator.ConsoleUI.Writers;
using System.Text.Json;
namespace Calculator.ConsoleUI;

class Program
{
    public static void Main()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Config", "operators.json");
        var json = File.ReadAllText(path);
        var config = JsonSerializer.Deserialize<OperatorConfig>(json)
                     ?? throw new Exception("Invalid config");
        var bootstrapper = new MyBootstrapper(config.Precedence);
        var expressionProcessor = bootstrapper.ProvideDependencies();
        var reader = new ConsoleReader();
        var writer = new ConsoleWriter();
        var runner = new Runner(expressionProcessor, reader, writer);
        runner.Run();
    }
}
