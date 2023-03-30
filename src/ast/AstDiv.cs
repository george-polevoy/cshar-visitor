namespace ast;

public class AstDiv : AstExpression
{
    public AstDiv(AstExpression left, AstExpression right)
    {
        Left = left;
        Right = right;
    }

    public AstExpression Left { get; }
    public AstExpression Right { get; }

    public override T Accept<T>(IAstExpressionVisitor<T> visitor)
    {
        return visitor.VisitDiv(this);
    }
}