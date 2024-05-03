namespace Katas.TicTacToe.App;

public class Game(IBoardState boardState, IBoardDrawer boardDrawer)
{
    private readonly List<char> _players = ['X', 'O'];
    private int _currentPlayerIndex;

    public string DrawBoard()
    {
        return boardDrawer.Draw(boardState.GetData());
    }

    public int NumberOfPlayers()
    {
        return _players.Count;
    }

    public bool IsGameOver()
    {
        return boardState.IsFull();
    }

    public void TakeField(int index)
    {
        var currentPlayer = _players[_currentPlayerIndex];
        boardState.TakeField(index, currentPlayer);
        _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
    }
}