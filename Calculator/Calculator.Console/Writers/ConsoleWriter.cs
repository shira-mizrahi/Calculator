namespace Calculator.ConsoleUI.Writers
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text); ;
        }
    }
}
