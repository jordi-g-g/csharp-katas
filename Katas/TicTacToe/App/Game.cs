namespace Katas.TicTacToe.App;

public class Game(IBoardDrawer boardDrawer)
{
    private readonly IBoardDrawer _boardDrawer = boardDrawer;

    public string DrawBoard()
    {
        var boardState = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        return _boardDrawer.Draw(boardState);
    }

    public int NumberOfPlayers()
    {
        return 2;
    }
}