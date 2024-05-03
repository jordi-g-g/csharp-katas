using Katas.TicTacToe.App.State;
using NUnit.Framework;

namespace Katas.TicTacToe.Tests.State;

public class BoardStateShould
{
    private BoardState _boardState;

    [SetUp]
    public void Setup()
    {
        _boardState = new BoardState();
    }

    [Test]
    public void BoardState_ShouldInitializeWithNineNumericFields()
    {
        Assert.That(9, Is.EqualTo(_boardState.GetData().Length));
        Assert.That(
            true,
            Is.EqualTo(
                _boardState.GetData().All(c => c is >= '1' and <= '9')
            )
        );
    }
}