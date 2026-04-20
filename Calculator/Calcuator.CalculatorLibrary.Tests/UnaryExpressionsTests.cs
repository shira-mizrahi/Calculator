using Calculator.CalculatorLibrary;
using Calculator.CalculatorLibrary.UnaryExpressions;
namespace Calcuator.CalculatorLibrary.Tests;

public class UnaryExpressionsTests
{

    [Fact]
    public void SquareRoot_NegativeNumber_ShouldThrowException()
    {
        var expr = new SquareRoot(new Number(-9));

        Assert.Throws<InvalidOperationException>(() => expr.Calculate());
    }
    [Theory]
    [InlineData(4, 2)]
    [InlineData(9, 3)]
    [InlineData(16, 4)]
    public void SquareRoot_ShouldReturnCorrectResult(double a, double expected)
    {
        var expr = new SquareRoot(new Number(a));

        var result = expr.Calculate();

        Assert.Equal(expected, result);
    }
    [Fact]
    public void Factorial_NegativeNumber_ShouldThrowException()
    {
        var expr = new Factorial(new Number(-3));

        Assert.Throws<InvalidOperationException>(() => expr.Calculate());
    }
    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(3, 6)]
    [InlineData(5, 120)]
    public void Factorial_ShouldReturnCorrectResult(double a, double expected)
    {
        var expr = new Factorial(new Number(a));

        var result = expr.Calculate();

        Assert.Equal(expected, result);
    }
}
