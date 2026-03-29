namespace Calculator.CalculatorLibrary
{
    //CR: OCP: what if I want to add more operators and precedence? will be a very large class
    public static class OperatorHelper
    {
        // CR: Clean Code: fields that are not used outside a class should be declared as private
        public static readonly Dictionary<string, int> Precedence = new()
        {
            ["+"] = 1,
            ["-"] = 1,
            ["*"] = 2,
            ["/"] = 2
        };

        // CR: Clean code: use the .net 8 convention for list
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