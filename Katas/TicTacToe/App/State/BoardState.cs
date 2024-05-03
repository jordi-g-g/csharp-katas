namespace Katas.TicTacToe.App.State;

public class BoardState : IBoardState
{
    private readonly char[] _data = new char[9];

    public BoardState()
    {
        InitializeBoardData();
    }

    public bool IsFull()
    {
        return true;
    }

    public char[] GetData()
    {
        return _data;
    }

    public void TakeField(int index, char player)
    {
        if (index < 0 || index >= _data.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
        
        if (_data[index] < '1' || _data[index] > '9')
        {
            throw new InvalidOperationException("Field is already taken.");
        }

        _data[index] = player;
    }

    private void InitializeBoardData()
    {
        for (var i = 0; i < _data.Length; i++)
        {
            _data[i] = (char)('0' + i + 1);
        }
    }
}