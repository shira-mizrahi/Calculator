namespace Calculator.Parser.Validators
{
    public interface IValidator
    {
        bool IsValid(List<string> tokens);
    }
}
