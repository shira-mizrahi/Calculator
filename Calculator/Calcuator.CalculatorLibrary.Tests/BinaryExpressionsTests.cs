
using Calculator.CalculatorLibrary.Abstraction;
using Calculator.CalculatorLibrary.BinaryExpressions;
using Calculator.CalculatorLibrary.UnaryExpressions;

namespace Calculator.CalculatorLibrary.Tests
{
    public class BinaryOperationsTests
    {
        [Theory]
        [InlineData(3, 4, 7)]
        [InlineData(-2, 5, 3)]
        public void Add_ShouldReturnSum(double a, double b, double expected)
        {
            var left = new Number(a);
            var right = new Number(b);

            var add = new Add(left, right);

            var result = add.Calculate();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 5, 5)]
        [InlineData(5, 10, -5)]
        public void Subtract_ShouldReturnDifference(double a, double b, double expected)
        {
            var left = new Number(a);
            var right = new Number(b);

            var subtract = new Subtract(left, right);

            var result = subtract.Calculate();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, 4, 12)]
        [InlineData(-2, 5, -10)]
        public void Multiply_ShouldReturnProduct(double a, double b, double expected)
        {
            var left = new Number(a);
            var right = new Number(b);

            var multiply = new Multiply(left, right);

            var result = multiply.Calculate();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(9, 3, 3)]
        public void Divide_ShouldReturnQuotient(double a, double b, double expected)
        {
            var left = new Number(a);
            var right = new Number(b);

            var divide = new Divide(left, right);

            var result = divide.Calculate();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Divide_ByZero_ShouldThrowException()
        {
            var left = new Number(10);
            var right = new Number(0);

            var divide = new Divide(left, right);

            Assert.Throws<DivideByZeroException>(() => divide.Calculate());
        }


        [Fact]
        public void NestedExpression_AddAndMultiply()
        {
            IExpression multiply = new Multiply(
                new Number(3),
                new Number(4)
            );

            IExpression expression = new Add(
                new Number(2),
                multiply
            );

            var result = expression.Calculate();

            Assert.Equal(14, result);
        }

        [Fact]
        public void NestedExpression_SubtractThenMultiply()
        {
            IExpression subtract = new Subtract(
                new Number(10),
                new Number(2)
            );

            IExpression expression = new Multiply(
                subtract,
                new Number(3)
            );


            var result = expression.Calculate();

            Assert.Equal(24, result);
        }
        [Fact]
        public void NestedExpression_SubtractAndDivisionByZero_ShouldThrowException()
        {
            var left = new Number(10);
            var subtract = new Subtract(
                new Number(3),
                new Number(3)
            );
            var expression = new Divide(left, subtract);
            Assert.Throws<DivideByZeroException>(() => expression.Calculate());

        }

        [Fact]
        public void ComplexNestedExpression()
        {
            IExpression divide = new Divide(
                new Number(20),
                new Number(5)
            );

            IExpression multiply = new Multiply(
                new Number(2),
                new Number(3)
            );

            IExpression expression = new Add(
                divide,
                multiply
            );

            var result = expression.Calculate();

            Assert.Equal(10, result);
        }
        [Theory]
        [InlineData(2, 3, 8)]
        [InlineData(5, 2, 25)]
        [InlineData(3, 3, 27)]
        public void Power_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            var expr = new Power(
                new Number(a),
                new Number(b)
            );

            var result = expr.Calculate();

            Assert.Equal(expected, result);
        }
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
}