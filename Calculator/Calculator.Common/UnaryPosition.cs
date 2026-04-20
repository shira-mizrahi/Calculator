using System.Text.Json.Serialization;

namespace Calculator.Common
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UnaryPosition
    {
        Prefix,
        Postfix
    }
}
