namespace Katas.TicTacToe.App.Cli;

public class CliBoardDrawer : IBoardDrawer
{
    public string Draw()
    {
        return "+---+---+---+\n" +
               "| 1 | 2 | 3 |\n" +
               "+---+---+---+\n" +
               "| 4 | 5 | 6 |\n" +
               "+---+---+---+\n" +
               "| 7 | 8 | 9 |\n" +
               "+---+---+---+\n";
    }
}