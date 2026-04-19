using Calculator.Common;

namespace Calculator.CalculatorLibrary;
public class OperatorHelper
{
    private readonly Dictionary<string, int> _precedence;
    private readonly Dictionary<string, bool> _isRightAssociative;


    public OperatorHelper(OperatorConfig operatorConfig)
    {
        _precedence = operatorConfig.Precedence;
        _isRightAssociative = operatorConfig.IsRightAssociative;
    }

    public int GetPrecedence(string op)
    {
        if (_precedence.TryGetValue(op, out var precedence))
            return precedence;

        throw new ArgumentException($"Unknown operator: {op}");
    }
    public bool IsRightAssociative(string op)
       => _isRightAssociative.TryGetValue(op, out var result) && result;

    public bool IsOperator(string op) => _precedence.ContainsKey(op);

    public IReadOnlyList<string> AllOperators => [.. _precedence.Keys];
}