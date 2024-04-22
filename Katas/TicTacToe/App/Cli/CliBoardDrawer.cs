namespace Katas.TicTacToe.App.Cli;

public class CliBoardDrawer: IBoardDrawer
{
    public string Draw()
    {
        const string board = """
                             +---+---+---+
                             | 1 | 2 | 3 |
                             +---+---+---+
                             | 4 | 5 | 6 |
                             +---+---+---+
                             | 7 | 8 | 9 |
                             +---+---+---+
                             """;
        return board;
    }
}