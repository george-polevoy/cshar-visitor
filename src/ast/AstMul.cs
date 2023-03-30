namespace ast;

public class AstMul : AstExpression
{
    public AstMul(AstExpression left, AstExpression right)
    {
        Left = left;
        Right = right;
    }

    public AstExpression Left { get; }
    public AstExpression Right { get; }

    public override T Accept<T>(IAstExpressionVisitor<T> visitor)
    {
        return visitor.VisitMul(this);
    }
}