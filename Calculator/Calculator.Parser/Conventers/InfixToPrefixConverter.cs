
using Calculator.CalculatorLibrary;

namespace Calculator.Parser.Conventers
{
    public class InfixToPrefixConverter : IConverter
    {
        public Tokenizer Tokenizer;
        private Dictionary<string, Action<string, Stack<string>, List<string>>> _tokenHandlers;

        public InfixToPrefixConverter(Tokenizer tokenizer)
        {
            Tokenizer = tokenizer;
            InitializeTokenHandlers();
        }
        private void InitializeTokenHandlers()
        {
            _tokenHandlers = new Dictionary<string, Action<string, Stack<string>, List<string>>>
            {
                ["("] = (token, operatorsStack, output) => operatorsStack.Push(token),
                [")"] = (token, operatorsStack, output) => PopOperatorsUntilLeftParen(operatorsStack, output)
            };
            foreach (var op in OperatorHelper.AllOperators)
            {
                _tokenHandlers[op] = HandleOperator;
            }
        }
        public List<string> Convert(List<string> tokens)
        {
            tokens.Reverse();
            var result = GetPostfixOrder(SwapParentheses(tokens));
            result.Reverse();
            return result;
        }
        private List<string> GetPostfixOrder(List<string> tokens)
        {
            var operatorsStack = new Stack<string>();
            var result = new List<string>();
            tokens.ForEach(token =>
            {
                {
                    if (_tokenHandlers.TryGetValue(token, out var handler))
                    {
                        handler(token, operatorsStack, result);
                    }
                    else if (double.TryParse(token, out _))
                    {
                        result.Add(token);
                    }
                    else
                    {
                        throw new ArgumentException($"Unknown token: {token}");
                    }
                }
            });
            while (operatorsStack.Count > 0)
            {
                result.Add(operatorsStack.Pop());
            }
            return result;
        }
        private void HandleOperator(string op, Stack<string> operatorsStack, List<string> result)
        {
            while (operatorsStack.Count > 0 && operatorsStack.Peek() != "(" &&
                  OperatorHelper.GetPrecedence(operatorsStack.Peek()) > OperatorHelper.GetPrecedence(op))
            {
                result.Add(operatorsStack.Pop());
            }
            operatorsStack.Push(op);
        }
        private void PopOperatorsUntilLeftParen(Stack<string> operatorsStack, List<string> result)
        {
            while (operatorsStack.Count > 0 && operatorsStack.Peek() != "(")
            {
                result.Add(operatorsStack.Pop());
            }
            if (operatorsStack.Count > 0) operatorsStack.Pop();
        }
        private List<string> SwapParentheses(List<string> tokens)
        {
            var swapped = new List<string>(tokens.Count);

            foreach (var token in tokens)
            {
                if (token == "(")
                    swapped.Add(")");
                else if (token == ")")
                    swapped.Add("(");
                else
                    swapped.Add(token);
            }
            return swapped;
        }

    }
}
