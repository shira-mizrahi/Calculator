using Calculator.Parser;
using Calculator.Parser.Abstract;
using Calculator.Parser.Conventers;
using Calculator.Parser.Parsers;
using Calculator.Parser.Validators;
using Calculator.Parser.Tokenizers;
using Calculator.CalculatorLibrary;
using static Calculator.Parser.Validators.InfixValidator;
using Calculator.CalculatorLibrary.BinaryExpressions;
using Calculator.CalculatorLibrary.UnaryExpressions;
using Calculator.CalculatorLibrary.Abstraction;
using Calculator.Common;
namespace Calculator.Bootstrapper;
public class MyBootstrapper
{
    private readonly OperatorConfig _config;

    public MyBootstrapper(OperatorConfig config)
    {
        _config = config;
    }
    public ExpressionProcessor ProvideDependencies()
    {
        //var operatorHelper = new OperatorHelper(_config.Operators);
        var operatorHelper = new OperatorHelper(_config.BinaryOperators,_config.UnaryOperators);

        var tokenizer = new SupportUnaryTokenizer();
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

        foreach (var op in _config.BinaryOperators.Keys)
        {
            infixValidatorHandlers[op] = infixValidator.HandleOperator;
        }
        foreach (var op in _config.UnaryOperators.Keys)
        {
            if (_config.UnaryOperators[op].Position=="prefix")
                infixValidatorHandlers[op] = infixValidator.HandleUnaryPrefix;
            else
                infixValidatorHandlers[op] = infixValidator.HandleUnaryPostfix;
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
            ["/"] = () => new Divide(),
            ["^"] = () => new Power(),
            ["√"] = () => new SquareRoot(),
            ["!"] = () => new Factorial()
        };
        return new ExpressionsFactory(expressions);
    }
}
