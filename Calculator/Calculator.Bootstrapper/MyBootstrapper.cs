using Calculator.Parser;
using Calculator.Parser.Abstract;
using Calculator.Parser.Conventers;
using Calculator.Parser.Parsers;
using Calculator.Parser.Validators;
using Calculator.Parser.Tokenizers;
using Calculator.CalculatorLibrary;
using static Calculator.Parser.Validators.InfixValidator;
using Calculator.CalculatorLibrary.BinaryExpressions;
using Calculator.CalculatorLibrary.Abstraction;
namespace Calculator.Bootstrapper;
public class MyBootstrapper
{
    private readonly Dictionary<string, int> _precedence;

    public MyBootstrapper(Dictionary<string, int> config)
    {
        _precedence = config;
    }
    public ExpressionProcessor ProvideDependencies()
    {
        var operatorHelper = new OperatorHelper(_precedence);
        var tokenizer = new BasicTokenizer();
        var converter = new InfixToPrefixConverter(tokenizer, operatorHelper);
        var parser = new PrefixExpressionParser(CreateExpressionsFactory());
        var validators = new List<IValidator>
        {
        CreateParenthesesBalancedValidator(),
        CreateInfixValidator()
        };
        var expressionProcessor = new ExpressionProcessor(tokenizer, validators, converter, parser);
        return expressionProcessor;
    }
    private InfixValidator CreateInfixValidator()
    {
        var infixValidatorHandlers = new Dictionary<string, TokenHandler>();
        var infixValidator = new InfixValidator(infixValidatorHandlers);
        infixValidatorHandlers["("] = infixValidator.HandleOpenParen;
        infixValidatorHandlers[")"] = infixValidator.HandleCloseParen;

        foreach (var op in _precedence.Keys)
        {
            infixValidatorHandlers[op] = infixValidator.HandleOperator;
        }
        return infixValidator;
    }
    private ParenthesesBalanced CreateParenthesesBalancedValidator()
    {
        var pairs = new Dictionary<string, string>
        {
            ["("] = ")"
        };
        return new ParenthesesBalanced(pairs);
    }
    private ExpressionsFactory CreateExpressionsFactory()
    {
        var expressions = new Dictionary<string, Func<IExpression>>()
        {
            ["+"] = () => new Add(),
            ["-"] = () => new Subtract(),
            ["*"] = () => new Multiply(),
            ["/"] = () => new Divide()
        };
        return new ExpressionsFactory(expressions);
    }
}
