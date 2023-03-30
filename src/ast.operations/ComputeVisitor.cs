namespace ast.operations;

public class ComputeVisitor : IAstExpressionVisitor<double>
{
    public double VisitConstant(AstConstant constant)
    {
        return constant.Value;
    }

    public double VisitSum(AstSumm sum)
    {
        return sum.Left.Accept(this) + sum.Right.Accept(this);
    }

    public double VisitMul(AstMul mul)
    {
        return mul.Left.Accept(this) * mul.Right.Accept(this);
    }

    public double VisitDiv(AstDiv div)
    {
        return div.Left.Accept(this) / div.Right.Accept(this);
    }
}