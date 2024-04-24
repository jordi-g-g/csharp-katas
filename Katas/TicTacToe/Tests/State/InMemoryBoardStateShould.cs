using Katas.TicTacToe.App.State;
using NUnit.Framework;

namespace Katas.TicTacToe.Tests.State;

public class InMemoryBoardStateShould
{
    private InMemoryBoardState _boardState;

    [SetUp]
    public void Setup()
    {
        _boardState = new InMemoryBoardState();
    }

    [Test]
    public void InMemoryBoardState_ShouldInitializeWithNineNumericFields()
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