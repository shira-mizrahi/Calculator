using Calculator.Common;

namespace Calculator.CalculatorLibrary;
//public class OperatorHelper
//{
//    private readonly Dictionary<string, int> _precedence;
//    private readonly Dictionary<string, bool> _isRightAssociative;
//    public OperatorHelper(OperatorConfig operatorConfig)
//    {
//        _precedence = operatorConfig.Precedence;
//        _isRightAssociative = operatorConfig.IsRightAssociative;
//    }
//    public int GetPrecedence(string op)
//    {
//        if (_precedence.TryGetValue(op, out var precedence))
//            return precedence;

//        throw new ArgumentException($"Unknown operator: {op}");
//    }
//    public bool IsRightAssociative(string op)
//       => _isRightAssociative.TryGetValue(op, out var result) && result;

//    public bool IsOperator(string op) => _precedence.ContainsKey(op);

//    public IReadOnlyList<string> AllOperators => [.. _precedence.Keys];
//}
//public class OperatorHelper
//{
//    private readonly Dictionary<string, OperatorInfo> _ops;

//    public OperatorHelper(Dictionary<string, OperatorInfo> ops)
//    {
//        _ops = ops;
//    }

//    public int GetPrecedence(string op) => _ops[op].Precedence;

//    public bool IsRightAssociative(string op) => _ops[op].RightAssociative;

//    public int GetArity(string op) => _ops[op].Arity;

//    public IEnumerable<string> AllOperators => _ops.Keys;
//}
public class OperatorHelper
{
    private readonly Dictionary<string, BinaryOperatorInfo> _binary;
    private readonly Dictionary<string, UnaryOperatorInfo> _unary;

    public OperatorHelper(
        Dictionary<string, BinaryOperatorInfo> binary,
        Dictionary<string, UnaryOperatorInfo> unary)
    {
        _binary = binary;
        _unary = unary;
    }
    public IReadOnlyList<string> AllOperators => _binary.Keys.Concat(_unary.Keys).ToList();
    public bool IsOperator(string op) => IsBinary(op)||IsUnary(op);
    public bool IsUnary(string op) => _unary.ContainsKey(op);
    public bool IsBinary(string op) => _binary.ContainsKey(op);

    public int GetPrecedence(string op)
        => IsBinary(op) ? _binary[op].Precedence : _unary[op].Precedence;

    public bool IsRightAssociative(string op)
        => IsBinary(op) && _binary[op].RightAssociative;

    public bool IsPostfix(string op)
        => IsUnary(op) && _unary[op].Position == "postfix";

    public bool IsPrefix(string op)
        => IsUnary(op) && _unary[op].Position == "prefix";
}