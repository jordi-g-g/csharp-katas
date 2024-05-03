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

    [TestCase(-1)]
    [TestCase(9)]
    public void ThrowArgumentOutOfRangeException_ForInvalidIndices(int index)
    {
        var boardState = new BoardState();
        const char player = 'X';

        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => boardState.TakeField(index, player));
        Assert.That(ex.ParamName, Is.EqualTo("index"));
        Assert.That(ex.Message, Does.Contain("Index is out of range."));
    }

    [Test]
    public void ThrowException_WhenTryingToTakeAnAlreadyTakenField()
    {
        var boardState = new BoardState();
        const int index = 0;
        const char firstPlayer = 'X';
        boardState.TakeField(index, firstPlayer);

        var ex = Assert.Throws<InvalidOperationException>(() => boardState.TakeField(index, 'O'));
        Assert.That(ex.Message, Is.EqualTo("Field is already taken."));
    }
}