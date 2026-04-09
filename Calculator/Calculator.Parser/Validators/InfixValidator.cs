using Calculator.Parser.Abstract;

namespace Calculator.Parser.Validators;

public class InfixValidator(Dictionary<string, InfixValidator.TokenHandler> handlers) : IValidator
{
    public delegate bool TokenHandler(string token, ref InfixValidatorStates state);
    private readonly Dictionary<string, TokenHandler> _handlers = handlers;

    public bool HandleNumber(ref InfixValidatorStates state)
    {
        if (state != InfixValidatorStates.ExpectedOperand) return false;
        state = InfixValidatorStates.ExpectedOperator;
        return true;
    }

    public bool HandleOperator(string token, ref InfixValidatorStates state)
    {
        if (state != InfixValidatorStates.ExpectedOperator) return false;
        state = InfixValidatorStates.ExpectedOperand;
        return true;
    }

    public bool HandleOpenParen(string token, ref InfixValidatorStates state)
    {
        if (state != InfixValidatorStates.ExpectedOperand) return false;
        return true;
    }

    public bool HandleCloseParen(string token, ref InfixValidatorStates state)
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
