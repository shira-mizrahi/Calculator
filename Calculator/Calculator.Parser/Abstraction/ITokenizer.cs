
namespace Calculator.Parser.Abstract;

public interface ITokenizer
{
    List<string> Tokenize(string input);
}
