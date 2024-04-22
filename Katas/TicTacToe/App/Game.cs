namespace Katas.TicTacToe.App;

public class Game(IBoardDrawer boardDrawer)
{
    private readonly IBoardDrawer _boardDrawer = boardDrawer;

    public string DrawBoard()
    {
        return _boardDrawer.Draw();
    }

    public int NumberOfPlayers()
    {
        return 2;
    }
}