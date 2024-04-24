namespace Katas.TicTacToe.App;

public class Game(IBoardDrawer boardDrawer, IBoardState boardState)
{
    private readonly IBoardDrawer _boardDrawer = boardDrawer;
    private readonly IBoardState _boardState = boardState;

    public string DrawBoard()
    {
        var boardState = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        return _boardDrawer.Draw(boardState);
    }

    public int NumberOfPlayers()
    {
        return 2;
    }

    public bool IsGameOver()
    {
        return _boardState.IsFull();
    }
}