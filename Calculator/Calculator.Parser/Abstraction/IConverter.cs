namespace Calculator.Parser.Abstract;

public interface IConverter
{
    List<string> Convert(List<string> tokens);
}
