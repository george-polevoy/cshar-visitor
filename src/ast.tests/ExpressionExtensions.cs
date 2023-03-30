namespace ast.tests;

public static class ExpressionExtensions
{
    public static double GetValue(this AstExpression expression)
    {
        return expression.Accept(new ComputeVisitor());
    }
}