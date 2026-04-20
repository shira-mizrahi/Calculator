using Calculator.CalculatorLibrary.Abstraction;
using Calculator.Parser.Abstract;
using Calculator.Parser.Tokenizers;

namespace Calculator.Parser;

public class ExpressionProcessor
{
    private ITokenizer _tokenizer;
    private List<IValidator> _validators;
    private IConverter _infixConverter;
    private IParser _parser;

    public ExpressionProcessor(ITokenizer tokenizer, List<IValidator> validators, IConverter infixConverter, IParser parser)
    {
        _tokenizer = tokenizer;
        _validators = validators;
        _infixConverter = infixConverter;
        _parser = parser;
    }
    public IExpression? GetExpression(string infix)
    {
        var tokens = _tokenizer.Tokenize(infix);
        if (!_validators.All(validator => validator.IsValid(tokens)))
        {
            throw new FormatException("invalid expression");
        }
        var converterResult = _infixConverter.Convert(tokens);
        return _parser.Parse(converterResult);
    }

}
