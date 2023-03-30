namespace ast.tests;

public class DivideByZeroConstantVisitor : IAstExpressionVisitor<bool>
{
    public bool VisitConstant(AstConstant constant)
    {
        return false;
    }

    public bool VisitSum(AstSumm sum)
    {
        return sum.Left.Accept(this) || sum.Right.Accept(this);
    }

    public bool VisitMul(AstMul mul)
    {
        return mul.Left.Accept(this) || mul.Right.Accept(this);
    }

    public bool VisitDiv(AstDiv div)
    {
        if (div.Left.Accept(this))
        {
            return true;
        }

        if (IsConstantZero(div.Right))
        {
            return true;
        }

        return false;
    }

    private bool IsConstantZero(AstExpression divRight)
    {
        return divRight.Accept(new IsConstantZeroVisitor());
    }
}