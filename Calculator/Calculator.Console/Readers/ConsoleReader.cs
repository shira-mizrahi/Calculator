namespace Calculator.ConsoleUI.Readers
{
    public class ConsoleReader : IReader
    {
        public string? Read() => Console.ReadLine();
    }
}
