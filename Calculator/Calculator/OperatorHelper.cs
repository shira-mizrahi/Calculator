

namespace Calculator.CalculatorLibrary
{
    public static class OperatorHelper
    {
        public static readonly Dictionary<string, int> Precedence = new()
        {
            ["+"] = 1,
            ["-"] = 1,
            ["*"] = 2,
            ["/"] = 2
        };

        public static readonly List<string> AllOperators = new(Precedence.Keys);
        public static int GetPrecedence(string op)
        {
            if (Precedence.TryGetValue(op, out var precedence))
                return precedence;

            throw new ArgumentException($"Unknown operator: {op}");
        }

        public static bool IsOperator(string op) => AllOperators.Contains(op);
    }
}