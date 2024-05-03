using Katas.TicTacToe.App;
using Katas.TicTacToe.App.State;
using Moq;
using NUnit.Framework;

namespace Katas.TicTacToe.Tests;

[TestFixture]
public class GameShould
{
    private Game _game;
    private Mock<BoardState> _boardState;
    private Mock<IBoardDrawer> _boardDrawer;

    [SetUp]
    public void Setup()
    {
        _boardState = new Mock<BoardState>();
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
        _boardState.Setup(bs => bs.IsFull()).Returns(false);

        Assert.That(false, Is.EqualTo(_game.IsGameOver()));
    }
    
    [Test]
    public void BeGameOver_WhenAllFieldsAreTaken()
    {
        _boardState.Setup(bs => bs.IsFull()).Returns(true);

        Assert.That(true, Is.EqualTo(_game.IsGameOver()));
    }
    
    [Test]
    public void AllowPlayerToTakeField_IfNotAlreadyTaken()
    {
        const int index = 0;
        const char player = 'O';
        _boardState.Setup(bs => bs.TakeField(index, player));

        _game.TakeField(index, player);

        _boardState.Verify(bs => bs.TakeField(index, player), Times.Once);
    }
}