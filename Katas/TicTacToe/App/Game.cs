namespace Katas.TicTacToe.App;

public class Game(IBoardState boardState, IBoardDrawer boardDrawer)
{
    private readonly IBoardState _boardState = boardState;
    private readonly IBoardDrawer _boardDrawer = boardDrawer;

    public string DrawBoard()
    {
        return _boardDrawer.Draw(_boardState.GetData());
    }

    public int NumberOfPlayers()
    {
        return 2;
    }

    public bool IsGameOver()
    {
        return _boardState.IsFull();
    }

    public void TakeField(int index, char player)
    {
        _boardState.TakeField(index, player);
    }
}