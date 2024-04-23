using System.Text;

namespace Katas.TicTacToe.App.Cli;

public class CliBoardDrawer : IBoardDrawer
{
    public string Draw(char[] boardState)
    {
        IsInvalidBoardState(boardState);

        var builder = new StringBuilder();
        builder.AppendLine("+---+---+---+");
        for (var i = 0; i < 9; i += 3)
        {
            builder.AppendLine($"| {boardState[i]} | {boardState[i + 1]} | {boardState[i + 2]} |");
            builder.AppendLine("+---+---+---+");
        }

        return builder.ToString();
    }

    private void IsInvalidBoardState(char[] boardState)
    {
        if (!BoardStateHasExactlyNineElements(boardState))
        {
            throw new ArgumentException("Board state must exactly contain 9 elements.");
        }

        if (!BoardStateContainsValidCharacters(boardState))
        {
            throw new ArgumentException(
                "Board state contains invalid characters. Only 'X', 'O', and numbers from 1 to 9 are allowed.");
        }
    }

    private static bool BoardStateHasExactlyNineElements(char[] boardState)
    {
        return boardState is { Length: 9 };
    }

    private static bool BoardStateContainsValidCharacters(char[] boardState)
    {
        return boardState.All(c => c is 'X' or 'O' or >= '1' and <= '9');
    }
}