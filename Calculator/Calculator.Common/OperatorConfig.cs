
namespace Calculator.Common
{
    public class OperatorConfig
    {
        public Dictionary<string, int> Precedence { get; set; } = [];
        public Dictionary<string, bool> IsRightAssociative { get; set; } = [];

    }
}
