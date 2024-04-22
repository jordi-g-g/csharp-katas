using NUnit.Framework;

namespace Katas.TicTacToe.Tests;

[TestFixture]
public class GameShould
{
    [Test]
    public void a_game_has_nine_fields_in_a_3x3_grid()
    {
        var game = new App.Game();
        var drawnBoard = game.DrawBoard();

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
}