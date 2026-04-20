namespace Calculator.Common
{
    public class OperatorInfo
    {
            public int Precedence { get; set; }
            public int Arity { get; set; }
            public bool RightAssociative { get; set; }
    }
}
