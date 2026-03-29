namespace Calculator.ConsoleUI.Readers
{
    // CR: Clean Code: should have an Abstraction folder that has all the interfaces and abstract classes
    public interface IReader
    {
        string? Read();
    }
}
