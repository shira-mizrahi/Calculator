using System.Text.Json.Serialization;

namespace Calculator.Common
{
    public class BinaryOperatorInfo
    {
        [JsonPropertyName("precedence")]
        public int Precedence { get; set; }
        [JsonPropertyName("rightAssociative")]
        public bool RightAssociative { get; set; }
    }
}