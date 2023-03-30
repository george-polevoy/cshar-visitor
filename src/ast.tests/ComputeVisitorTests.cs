namespace ast.tests;

public class AnalysisTests
{
    [Test]
    public void DivideByZeroConstantSimple()
    {
        AstExpression expression =
            new AstDiv(
                new AstConstant(1),
                new AstConstant(0));

        var actual = expression.Accept(new DivideByZeroConstantVisitor());

        Assert.IsTrue(actual);
    }

    [Test]
    public void DivideByZeroConstantComplex()
    {
        AstExpression expression =
            new AstSumm(
                new AstDiv(
                    new AstMul(
                        new AstConstant(1),
                        new AstConstant(2)),
                    new AstConstant(0)),
                new AstConstant(1));

        var actual = expression.Accept(new DivideByZeroConstantVisitor());

        Assert.IsTrue(actual);
    }
}

public class ToStringVisitorTests
{
    [Test]
    public void CanComputeAstString()
    {
        AstExpression expression =
            new AstMul(
                new AstSumm(
                    new AstConstant(1),
                    new AstConstant(2)
                ),
                new AstConstant(3));

        var expected = "((1 + 2) * 3)";

        Assert.That(expression.Accept(new ToStringVisitor()), Is.EqualTo(expected));
    }
}

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