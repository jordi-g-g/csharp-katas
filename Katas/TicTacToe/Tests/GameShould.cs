using Katas.TicTacToe.App;
using Moq;
using NUnit.Framework;

namespace Katas.TicTacToe.Tests;

[TestFixture]
public class GameShould
{
    private Game _game;
    private Mock<IBoardState> _boardState;
    private Mock<IBoardDrawer> _boardDrawer;

    [SetUp]
    public void Setup()
    {
        _boardState = new Mock<IBoardState>();
        _boardDrawer = new Mock<IBoardDrawer>();
        _game = new Game(_boardState.Object, _boardDrawer.Object);
    }

    [Test]
    public void HasTwoPlayers_ByDefault()
    {
        Assert.That(2, Is.EqualTo(_game.NumberOfPlayers()));
    }

    [Test]
    public void RetrieveDataAndDrawOnce_WhenDrawBoardCalled()
    {
        var expectedBoardData = new char[9];
        const string expectedBoardDrawn = "foo";
        _boardState.Setup(bs => bs.GetData()).Returns(expectedBoardData);
        _boardDrawer.Setup(bd => bd.Draw(expectedBoardData))
            .Returns(expectedBoardDrawn);

        _game.DrawBoard();

        _boardState.Verify(bs => bs.GetData(), Times.Once);
        _boardDrawer.Verify(bd => bd.Draw(expectedBoardData), Times.Once);
    }

    [Test]
    public void NotBeGameOver_WhenAllFieldsAreNotTaken()
    {
        _boardState.Setup(bs => bs.IsGameOver()).Returns(false);

        Assert.That(_game.IsGameOver(), Is.False);
    }

    [Test]
    public void BeGameOver_WhenAllFieldsAreTaken()
    {
        _boardState.Setup(bs => bs.IsGameOver()).Returns(true);

        Assert.That(_game.IsGameOver(), Is.True);
    }

    [Test]
    public void AllowPlayerToTakeField_IfNotAlreadyTaken()
    {
        const int index = 0;
        const char player = 'X';

        _game.TakeField(index);

        _boardState.Verify(bs => bs.TakeField(index, player), Times.Once);
    }

    [Test]
    public void ThrowException_WhenFieldIsAlreadyTaken()
    {
        const int index = 0;
        const char currentPlayer = 'X';

        _boardState.Setup(bs => bs.TakeField(index, currentPlayer))
            .Throws(new InvalidOperationException());

        Assert.Throws<InvalidOperationException>(() => _game.TakeField(index));

        _boardState.Verify(bs => bs.TakeField(index, currentPlayer), Times.Once);
    }

    private static readonly char[] AlternatePlayersCollection = ['X', 'O', 'X'];

    [Test]
    public void AlternatePlayersTurn()
    {
        var turns = new Queue<char>(AlternatePlayersCollection);
        _boardState.Setup(bs => bs.TakeField(It.IsAny<int>(), It.IsAny<char>()))
            .Callback<int, char>((index, player) => { Assert.That(player, Is.EqualTo(turns.Dequeue())); });

        for (var i = 0; i < AlternatePlayersCollection.Length; i++)
        {
            _game.TakeField(i);
        }

        Assert.That(turns, Is.Empty);
    }
}