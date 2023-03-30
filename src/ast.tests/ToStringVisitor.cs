using System.Globalization;

namespace ast.tests;

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

public class ToStringVisitor : IAstExpressionVisitor<string>
{
    public string VisitConstant(AstConstant constant)
    {
        return constant.Value.ToString(CultureInfo.InvariantCulture);
    }

    public string VisitSum(AstSumm sum)
    {
        return $"({sum.Left.Accept(this)} + {sum.Right.Accept(this)})";
    }

    public string VisitMul(AstMul mul)
    {
        return $"({mul.Left.Accept(this)} * {mul.Right.Accept(this)})";
    }

    public string VisitDiv(AstDiv div)
    {
        return $"({div.Left.Accept(this)} / {div.Right.Accept(this)})";
    }
}