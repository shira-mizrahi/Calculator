using System.Text.Json.Serialization;

namespace Calculator.Common
{
    public class UnaryOperatorInfo
    {
        [JsonPropertyName("precedence")]
        public int Precedence { get; set; }
        [JsonPropertyName("position")]
        public UnaryPosition Position { get; set; }
    }
}