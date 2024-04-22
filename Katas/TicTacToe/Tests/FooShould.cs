using NUnit.Framework;

namespace Katas.TicTacToe.Tests;

[TestFixture]
public class FooShould
{
    [Test]
    public void be_true()
    {
        Assert.That(true, Is.EqualTo(true));
    }
}