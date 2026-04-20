
namespace Calculator.Common
{
    public class OperatorConfig
    {
        public Dictionary<string, BinaryOperatorInfo> BinaryOperators { get; set; } = [];
        public Dictionary<string, UnaryOperatorInfo> UnaryOperators { get; set; } = [];

    }
}
