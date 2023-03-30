namespace ast;

public class AstConstant : AstExpression
{
    public AstConstant(double value)
    {
        Value = value;
    }

    public double Value { get; }
    public override T Accept<T>(IAstExpressionVisitor<T> visitor)
    {
        return visitor.VisitConstant(this);
    }
}