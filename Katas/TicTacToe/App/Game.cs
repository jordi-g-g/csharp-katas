using Katas.TicTacToe.App.State;

namespace Katas.TicTacToe.App;

public class Game(BoardState boardState, IBoardDrawer boardDrawer)
{
    private readonly BoardState _boardState = boardState;
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
}