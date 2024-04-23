using Katas.TicTacToe.App.Cli;
using NUnit.Framework;

namespace Katas.TicTacToe.Tests.Cli;

public class CliBoardDrawerShould
{
    [Test]
    public void Draw_ReturnsCorrect3x3Grid()
    {
        var game = new CliBoardDrawer();

        var drawnBoard = game.Draw();

        const string expected = "+---+---+---+\n" +
                                "| 1 | 2 | 3 |\n" +
                                "+---+---+---+\n" +
                                "| 4 | 5 | 6 |\n" +
                                "+---+---+---+\n" +
                                "| 7 | 8 | 9 |\n" +
                                "+---+---+---+\n";
        Assert.That(drawnBoard, Is.EqualTo(expected));
    }
}