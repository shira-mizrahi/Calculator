using Calculator.Parser;
using Calculator.Parser.Conventers;
using Calculator.Parser.Parsers;
using Calculator.Parser.Validators;
namespace Calculator.Bootstrapper
{
    public class MyBootstrapper
    {
        public ExpressionProcessor ProvideDependencies()
        {
            var tokenizer = new Tokenizer();
            var converter = new InfixToPrefixConverter(tokenizer);
            var parser = new PrefixExpressionParser(new ExpressionsFactory());
            List<IValidator> validators = new List<IValidator>()
            {
                new ParenthesesBalanced(),
                new InfixValidator()
            };
            var expressionProcessor = new ExpressionProcessor(tokenizer, validators, converter, parser);
            return expressionProcessor;
        }
    }
}
