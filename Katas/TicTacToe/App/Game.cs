namespace Katas.TicTacToe.App;

public class Game
{
    public string DrawBoard()
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