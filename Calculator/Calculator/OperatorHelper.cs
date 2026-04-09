namespace Calculator.CalculatorLibrary;
public class OperatorHelper
{
    private readonly Dictionary<string, int> _precedence;

    public OperatorHelper(Dictionary<string, int> precedence)
    {
        _precedence = precedence;
    }

    public int GetPrecedence(string op)
    {
        if (_precedence.TryGetValue(op, out var precedence))
            return precedence;

        throw new ArgumentException($"Unknown operator: {op}");
    }

    public bool IsOperator(string op) => _precedence.ContainsKey(op);

    public IReadOnlyList<string> AllOperators => [.. _precedence.Keys];
}