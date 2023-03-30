namespace ast;

public abstract class AstExpression
{
    public abstract T Accept<T>(IAstExpressionVisitor<T> visitor);
}

public interface IAstExpressionVisitor<out T>
{
    T VisitConstant(AstConstant constant);
    T VisitSum(AstSumm sum);
    T VisitMul(AstMul mul);
    T VisitDiv(AstDiv div);
}
