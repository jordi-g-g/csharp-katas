using Katas.TicTacToe.App.Cli;
using NUnit.Framework;

namespace Katas.TicTacToe.Tests.Cli;

public class CliBoardDrawerShould
{
    private CliBoardDrawer _drawer;

    [SetUp]
    public void Setup()
    {
        _drawer = new CliBoardDrawer();
    }

    [TestCase(
        new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' },
        "+---+---+---+\n" +
        "| 1 | 2 | 3 |\n" +
        "+---+---+---+\n" +
        "| 4 | 5 | 6 |\n" +
        "+---+---+---+\n" +
        "| 7 | 8 | 9 |\n" +
        "+---+---+---+\n")]
    [TestCase(
        new[] { 'X', 'O', '3', '4', '5', '6', '7', '8', 'X' },
        "+---+---+---+\n" +
        "| X | O | 3 |\n" +
        "+---+---+---+\n" +
        "| 4 | 5 | 6 |\n" +
        "+---+---+---+\n" +
        "| 7 | 8 | X |\n" +
        "+---+---+---+\n")]
    [TestCase(
        new[] { 'X', 'O', 'X', 'O', 'X', 'O', 'X', 'O', '9' },
        "+---+---+---+\n" +
        "| X | O | X |\n" +
        "+---+---+---+\n" +
        "| O | X | O |\n" +
        "+---+---+---+\n" +
        "| X | O | 9 |\n" +
        "+---+---+---+\n")]
    public void DrawBoard_CorrectlyBasedOnInput(char[] boardState, string expected)
    {
        var drawnBoard = _drawer.Draw(boardState);

        Assert.That(drawnBoard, Is.EqualTo(expected));
    }

    [Test]
    public void ThrowArgumentException_WhenBoardStateIsNull()
    {
        Assert.That(
            () => _drawer.Draw(null),
            Throws.TypeOf<ArgumentException>()
                .With.Message.EqualTo("Board state must exactly contain 9 elements.")
        );
    }

    [Test]
    public void ThrowArgumentException_WhenBoardStateIsNotExactly9Elements()
    {
        var boardState = new char[] { 'X' };
        Assert.That(
            () => _drawer.Draw(boardState),
            Throws.TypeOf<ArgumentException>()
                .With.Message.EqualTo("Board state must exactly contain 9 elements.")
        );
    }
    
    [Test]
    public void ThrowArgumentException_WhenValueOnBoardState_Q_IsNotAllowed()
    {
        var boardState = new char[] { 'Q', 'O', 'X', 'O', 'X', 'O', 'X', 'O', '9' };
        Assert.That(
            () => _drawer.Draw(boardState),
            Throws.TypeOf<ArgumentException>()
                .With.Message.EqualTo("Board state contains invalid characters. Only 'X', 'O', and numbers from 1 to 9 are allowed.")
        );
    }
    
    [Test]
    public void ThrowArgumentException_WhenValueOnBoardState_0_IsNotAllowed()
    {
        var boardState = new char[] { '0', 'O', 'X', 'O', 'X', 'O', 'X', 'O', '9' };
        Assert.That(
            () => _drawer.Draw(boardState),
            Throws.TypeOf<ArgumentException>()
                .With.Message.EqualTo("Board state contains invalid characters. Only 'X', 'O', and numbers from 1 to 9 are allowed.")
        );
    }
}