using Katas.TicTacToe.App;
using Katas.TicTacToe.App.Cli;
using Moq;
using NUnit.Framework;

namespace Katas.TicTacToe.Tests;

[TestFixture]
public class GameShould
{
    private Game _game;
    private Mock<IBoardState> _boardState;

    [SetUp]
    public void Setup()
    {
        var boardDrawer = new CliBoardDrawer();
        _boardState = new Mock<IBoardState>();
        _game = new Game(boardDrawer, _boardState.Object);
    }

    [Test]
    public void HasTwoPlayers_ByDefault()
    {
        Assert.That(2, Is.EqualTo(_game.NumberOfPlayers()));
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
}