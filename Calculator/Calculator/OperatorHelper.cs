using Calculator.Common;

namespace Calculator.CalculatorLibrary;
public class OperatorHelper
{
    private readonly Dictionary<string, BinaryOperatorInfo> _binary;
    private readonly Dictionary<string, UnaryOperatorInfo> _unary;

    public OperatorHelper(OperatorConfig operatorConfig)
    {
        _binary = operatorConfig.BinaryOperators;
        _unary = operatorConfig.UnaryOperators;
    }
    public IReadOnlyList<string> AllOperators => [.. _binary.Keys, .. _unary.Keys];
    public bool IsOperator(string op) => IsBinary(op) || IsUnary(op);
    public bool IsUnary(string op) => _unary.ContainsKey(op);
    public bool IsBinary(string op) => _binary.ContainsKey(op);

    public int GetPrecedence(string op)
        => IsBinary(op) ? _binary[op].Precedence : _unary[op].Precedence;

    public bool IsRightAssociative(string op)
        => IsBinary(op) && _binary[op].RightAssociative;

    public bool IsPostfix(string op)
        => IsUnary(op) && _unary[op].Position == UnaryPosition.Postfix;

    public bool IsPrefix(string op)
        => IsUnary(op) && _unary[op].Position == UnaryPosition.Prefix;
}