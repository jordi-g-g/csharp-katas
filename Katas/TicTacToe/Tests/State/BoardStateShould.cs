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

    public static IEnumerable<TestCaseData> BoardFillScenarios()
    {
        yield return new TestCaseData(
            new List<(int index, char player)> { (0, 'X') },
            false
        ).SetName("a player can take a field if not already taken");
        yield return new TestCaseData(
            new List<(int index, char player)>
            {
                (0, 'X'), (1, 'O'), (2, 'X'),
                (3, 'O'), (4, 'X'), (5, 'O'),
                (6, 'O'), (7, 'X'), (8, 'O')
            },
            true
        ).SetName("players take turns taking fields until the game is over");
        yield return new TestCaseData(
            new List<(int index, char player)>
            {
                (0, 'X'), (1, 'O'), (2, 'O'),
                (3, 'X'), (4, 'O'), (5, 'O'),
                (6, 'X')
            },
            true
        ).SetName("a game is over when all fields in column 1 are taken by a player");
        yield return new TestCaseData(
            new List<(int index, char player)>
            {
                (0, 'X'), (1, 'O'), (2, 'X'),
                (3, 'O'), (4, 'O'), (5, 'O'),
                (6, 'X'), (7, 'O')
            },
            true
        ).SetName("a game is over when all fields in column 2 are taken by a player");
    }

    [Test, TestCaseSource(nameof(BoardFillScenarios))]
    public void CalculateGameOver_WhenFieldsAreTaken(
        IEnumerable<(int index, char player)> moves,
        bool expectedGameOver
    )
    {
        foreach (var move in moves)
        {
            _boardState.TakeField(move.index, move.player);
        }

        Assert.That(_boardState.IsGameOver(), Is.EqualTo(expectedGameOver));
    }
}