using Calculator.Parser.Abstract;

namespace Calculator.Parser.Validators;

public class ParenthesesBalanced(Dictionary<string, string> pairs) : IValidator
{
    private readonly Dictionary<string, string> _pairs = pairs;

    public bool IsValid(List<string> tokens)
    {
        var stack = new Stack<string>();
        foreach (var token in tokens)
        {
            if (_pairs.Keys.Any(key => key == token)) stack.Push(token);
            else if (_pairs.Values.Any(value => value == token))
            {
                if (stack.Count == 0 || stack.Pop() != _pairs.Keys.First(key => _pairs[key] == token))
                    return false;
            }
        }
        return stack.Count == 0;
    }
}
