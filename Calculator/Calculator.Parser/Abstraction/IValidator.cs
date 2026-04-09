namespace Calculator.Parser.Abstract;

public interface IValidator
{
    bool IsValid(List<string> tokens);
}
