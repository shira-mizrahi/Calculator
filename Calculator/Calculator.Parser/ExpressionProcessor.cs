using Calculator.CalculatorLibrary;
using Calculator.Parser.Conventers;
using Calculator.Parser.Parsers;
using Calculator.Parser.Validators;

namespace Calculator.Parser
{
    public class ExpressionProcessor
    {
        // CR: Clean Code: fields that are not used outside a class should be declared as private
        public Tokenizer Tokenizer;
        public List<IValidator> Validators;
        public IConverter InfixConverter;
        public IParser Parser;

        public ExpressionProcessor(Tokenizer tokenizer, List<IValidator> validators, IConverter infixConverter, IParser parser)
        {
            Tokenizer = tokenizer;
            Validators = validators;
            InfixConverter = infixConverter;
            Parser = parser;
        }
        public IExpression? GetExpression(string infix)
        {
            var tokens = Tokenizer.Tokenize(infix);
            // CR: Clean Code: should never use == true, just use the boolean statement 
            if (!Validators.All(validator => validator.IsValid(tokens) == true))
            {
                throw new FormatException("invalid expression");
            }
            var converterResult = InfixConverter.Convert(tokens);
            return Parser.Parse(converterResult);
        }

    }
}
