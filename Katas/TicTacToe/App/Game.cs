namespace Katas.TicTacToe.App;

public class Game(IBoardState boardState, IBoardDrawer boardDrawer)
{
    private readonly IBoardState _boardState = boardState;
    private readonly IBoardDrawer _boardDrawer = boardDrawer;
    private readonly List<char> _players = ['X', 'O'];
    private int _currentPlayerIndex = 0;

    public string DrawBoard()
    {
        return _boardDrawer.Draw(_boardState.GetData());
    }

    public int NumberOfPlayers()
    {
        return _players.Count;
    }

    public bool IsGameOver()
    {
        return _boardState.IsFull();
    }

    public void TakeField(int index)
    {
        var currentPlayer = _players[_currentPlayerIndex];
        _boardState.TakeField(index, currentPlayer);
        _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
    }
}