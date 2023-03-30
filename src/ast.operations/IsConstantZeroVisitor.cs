namespace ast.operations;

public class IsConstantZeroVisitor : IAstExpressionVisitor<bool>
{
    public bool VisitConstant(AstConstant constant)
    {
        return constant.Value == 0;
    }

    public bool VisitSum(AstSumm sum)
    {
        return false;
    }

    public bool VisitMul(AstMul mul)
    {
        return false;
    }

    public bool VisitDiv(AstDiv div)
    {
        return false;
    }
}