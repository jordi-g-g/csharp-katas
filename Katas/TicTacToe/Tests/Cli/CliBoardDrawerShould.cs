using Katas.TicTacToe.App.Cli;
using NUnit.Framework;

namespace Katas.TicTacToe.Tests.Cli;

public class CliBoardDrawerShould
{
    [TestCase(
        new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' },
        "+---+---+---+\n" +
        "| 1 | 2 | 3 |\n" +
        "+---+---+---+\n" +
        "| 4 | 5 | 6 |\n" +
        "+---+---+---+\n" +
        "| 7 | 8 | 9 |\n" +
        "+---+---+---+\n")]
    [TestCase(
        new char[] { 'X', 'O', '3', '4', '5', '6', '7', '8', '9' },
        "+---+---+---+\n" +
        "| X | O | 3 |\n" +
        "+---+---+---+\n" +
        "| 4 | 5 | 6 |\n" +
        "+---+---+---+\n" +
        "| 7 | 8 | 9 |\n" +
        "+---+---+---+\n")]
    [TestCase(
        new char[] { 'X', 'O', 'X', 'O', 'X', 'O', 'X', 'O', '9' },
        "+---+---+---+\n" +
        "| X | O | X |\n" +
        "+---+---+---+\n" +
        "| O | X | O |\n" +
        "+---+---+---+\n" +
        "| X | O | 9 |\n" +
        "+---+---+---+\n")]
    public void DrawBoard_CorrectlyBasedOnInput(char[] boardState, string expected)
    {
        var game = new CliBoardDrawer();

        var drawnBoard = game.Draw(boardState);

        Assert.That(drawnBoard, Is.EqualTo(expected));
    }
}