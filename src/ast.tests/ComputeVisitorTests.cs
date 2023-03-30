using ast.operations;

namespace ast.tests;

public class ComputeVisitorTests
{
    [TestCase(1)]
    [TestCase(2)]
    public void ConstantGetValue(double expected)
    {
        AstExpression expression = new AstConstant(expected);
        var visitor = new ComputeVisitor();
        Assert.That(expression.GetValue(), Is.EqualTo(expected));
    }

    [TestCase(1, 2, 4)]
    [TestCase(5, 7, 13)]
    public void CanComputeComplexExpr(double a, double b, double expected)
    {
        AstExpression expression =
            new AstSumm(
                new AstSumm(
                    new AstConstant(a),
                    new AstConstant(1)
                ),
                new AstConstant(b));

        Assert.That(expression.GetValue(), Is.EqualTo(expected));
    }

    [TestCase(1, 2, 3)]
    [TestCase(5, 7, 12)]
    public void CanComputeAdd(double a, double b, double expected)
    {
        AstExpression expression =
            new AstSumm(
                new AstConstant(a),
                new AstConstant(b));

        Assert.That(expression.GetValue(), Is.EqualTo(expected));
    }

    [TestCase(2, 4, 8)]
    [TestCase(5, 7, 35)]
    public void CanComputeMul(double a, double b, double expected)
    {
        AstExpression expression =
            new AstMul(
                new AstConstant(a),
                new AstConstant(b));

        Assert.That(expression.GetValue(), Is.EqualTo(expected));
    }

    [TestCase(8, 2, 4)]
    [TestCase(35, 5, 7)]
    public void CanComputeDiv(double a, double b, double expected)
    {
        AstExpression expression =
            new AstDiv(
                new AstConstant(a),
                new AstConstant(b));

        Assert.That(expression.GetValue(), Is.EqualTo(expected));
    }
}