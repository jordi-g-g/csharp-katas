using System.Text;

namespace Katas.TicTacToe.App.Cli;

public class CliBoardDrawer : IBoardDrawer
{
    public string Draw(char[] boardState)
    {
        if (boardState is not { Length: 9 })
        {
            throw new ArgumentException("Board state must exactly contain 9 elements.");
        }
        
        var builder = new StringBuilder();
        builder.AppendLine("+---+---+---+");
        for (var i = 0; i < 9; i += 3)
        {
            builder.AppendLine($"| {boardState[i]} | {boardState[i + 1]} | {boardState[i + 2]} |");
            builder.AppendLine("+---+---+---+");
        }

        return builder.ToString();
    }
}