
using Calculator.CalculatorLibrary;

namespace Calculator.Parser.Validators
{
    public enum InfixValidatorStates
    {
        ExpectedOperand,
        ExpectedOperator
    }

    public class InfixValidator : IValidator
    {
        private delegate bool TokenHandler(string token, ref InfixValidatorStates state);
        private Dictionary<string, TokenHandler> _handlers;

        public InfixValidator()
        {
            InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            _handlers = new Dictionary<string, TokenHandler>
            {
                ["("] = HandleOpenParen,
                [")"] = HandleCloseParen
            };
            foreach (var op in OperatorHelper.AllOperators)
            {
                _handlers[op] = HandleOperator;
            }
        }
        private bool HandleNumber(ref InfixValidatorStates state)
        {
            if (state != InfixValidatorStates.ExpectedOperand) return false;
            state = InfixValidatorStates.ExpectedOperator;
            return true;
        }

        private bool HandleOperator(string token, ref InfixValidatorStates state)
        {
            if (state != InfixValidatorStates.ExpectedOperator) return false;
            state = InfixValidatorStates.ExpectedOperand;
            return true;
        }

        private bool HandleOpenParen(string token, ref InfixValidatorStates state)
        {
            if (state != InfixValidatorStates.ExpectedOperand) return false;
            return true;
        }

        private bool HandleCloseParen(string token, ref InfixValidatorStates state)
        {
            if (state != InfixValidatorStates.ExpectedOperator) return false;
            return true;
        }
        public bool IsValid(List<string> tokens)
        {
            var state = InfixValidatorStates.ExpectedOperand;
            foreach (var token in tokens)
            {
                if (double.TryParse(token, out _))
                {
                    if (!HandleNumber(ref state)) return false;
                    continue;
                }
                if (_handlers.TryGetValue(token, out var handler))
                {
                    if (!handler(token, ref state)) return false;
                }
                else
                {
                    return false;
                }
            }

            return state == InfixValidatorStates.ExpectedOperator;
        }
    }
}