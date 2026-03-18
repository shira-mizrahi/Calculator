namespace Calculator.Parser.Conventers
{
    public interface IConverter
    {
        List<string> Convert(List<string> tokens);
    }
}
