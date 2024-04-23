using Katas.TicTacToe.App.Cli;
using NUnit.Framework;

namespace Katas.TicTacToe.Tests;

[TestFixture]
public class GameShould
{
    private App.Game _game;

    [SetUp]
    public void Setup()
    {
        var boardDrawer = new CliBoardDrawer();
        _game = new App.Game(boardDrawer);
    }

    [Test]
    public void has_two_players_in_the_game()
    {
        Assert.That(2, Is.EqualTo(_game.NumberOfPlayers()));
    }
}