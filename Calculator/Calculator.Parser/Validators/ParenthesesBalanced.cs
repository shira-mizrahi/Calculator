namespace Calculator.Parser.Validators
{
    public class ParenthesesBalanced : IValidator
    {
        // CR: SOLID - DIP: should not have configuration outside of bootstrap
        private readonly Dictionary<string, string> _pairs = new()
        {
        { "(", ")" }
        };

        public bool IsValid(List<string> tokens)
        {
            var stack = new Stack<string>();
            foreach (var token in tokens)
            {
                if (_pairs.Keys.Any(key => key == token)) stack.Push(token);
                else if (_pairs.Values.Any(value => value == token))
                {
                    // CR: LINQ: when using Where(...).First(), you can use First(...) only
                    if (stack.Count == 0 || stack.Pop() != _pairs.Keys.Where(key => _pairs[key] == token).First())
                        return false;
                }
            }
            return stack.Count == 0;
        }
    }
}
