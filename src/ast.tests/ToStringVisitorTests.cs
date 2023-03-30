using ast.operations;

namespace ast.tests;

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