namespace Katas.TicTacToe.App.State;

public class BoardState : IBoardState
{
    private char[] _data = new char[9];

    public BoardState()
    {
        InitializeBoardData();
    }

    public bool IsGameOver()
    {
        return _data.All(c => c is 'X' or 'O');
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
        _data = Enumerable.Range(1, 9).Select(x => (char)('0' + x)).ToArray();
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