namespace Katas.TicTacToe.App.State;

public class BoardState : IBoardState
{
    private readonly char[] _data = new char[9];

    public BoardState()
    {
        InitializeBoardData();
    }

    public bool IsGameOver()
    {
        return true;
    }

    public char[] GetData()
    {
        return _data;
    }

    public void TakeField(int index, char player)
    {
        ValidateIndex(index);
        ValidateFieldNotTaken(index);

        _data[index] = player;
    }

    private void InitializeBoardData()
    {
        for (var i = 0; i < _data.Length; i++)
        {
            _data[i] = (char)('0' + i + 1);
        }
    }
    
    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= _data.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
    }
    
    private void ValidateFieldNotTaken(int index)
    {
        if (_data[index] < '1' || _data[index] > '9')
        {
            throw new InvalidOperationException("Field is already taken.");
        }
    }
}