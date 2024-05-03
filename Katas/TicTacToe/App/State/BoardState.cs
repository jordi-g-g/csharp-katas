namespace Katas.TicTacToe.App.State;

public class BoardState
{
    private readonly char[] _data = new char[9];

    public BoardState()
    {
        InitializeBoardData();
    }

    public virtual bool IsFull()
    {
        return true;
    }

    public virtual char[] GetData()
    {
        return _data;
    }

    public virtual void TakeField(int index, char player)
    {
        throw new NotImplementedException();
    }

    private void InitializeBoardData()
    {
        for (var i = 0; i < _data.Length; i++)
        {
            _data[i] = (char)('0' + i + 1);
        }
    }
}