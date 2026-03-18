using Calculator.Bootstrapper;
using Calculator.ConsoleUI.Readers;
using Calculator.ConsoleUI.Writers;
namespace Calculator.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            var bootstrapper = new MyBootstrapper();
            var expressionProcessor = bootstrapper.ProvideDependencies();
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var runner = new Runner(expressionProcessor, reader, writer);
            runner.Run();
        }
    }
}
