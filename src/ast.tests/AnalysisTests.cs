using ast.operations;

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