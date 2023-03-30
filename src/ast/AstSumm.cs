namespace ast;

public class AstSumm : AstExpression
{
    public AstExpression Left { get; }
    public AstExpression Right { get; }

    public AstSumm(AstExpression left, AstExpression right)
    {
        Left = left;
        Right = right;
    }

    public override T Accept<T>(IAstExpressionVisitor<T> visitor)
    {
        return visitor.VisitSum(this);
    }
}