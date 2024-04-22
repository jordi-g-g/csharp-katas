using NUnit.Framework;

namespace Katas.TicTacToe.Tests;

[TestFixture]
public class GameShould
{
    private App.Game _game;

    [SetUp]
    public void Setup()
    {
        _game = new App.Game();
    }
    
    [Test]
    public void has_nine_fields_in_a_3x3_grid()
    {
        var drawnBoard = _game.DrawBoard();

        const string expected = """
                                +---+---+---+
                                | 1 | 2 | 3 |
                                +---+---+---+
                                | 4 | 5 | 6 |
                                +---+---+---+
                                | 7 | 8 | 9 |
                                +---+---+---+
                                """;
        Assert.That(expected, Is.EqualTo(drawnBoard));
    }

    [Test]
    public void has_two_players_in_the_game() {
        Assert.That(2, Is.EqualTo(_game.NumberOfPlayers()));
    }
}