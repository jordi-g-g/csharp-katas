namespace Katas.TicTacToe.App.State;

public class BoardState : IBoardState
{
    private char[] _data = new char[9];
    private const int BoardDimension = 3;

    public BoardState()
    {
        InitializeBoardData();
    }

    public bool IsGameOver()
    {
        return AreAllFieldsTaken() || IsAnyWinConditionMatched();
    }

    private bool AreAllFieldsTaken()
    {
        return _data.All(c => c is 'X' or 'O');
    }

    private bool IsAnyWinConditionMatched()
    {
        var winConditions = new List<List<int>>
        {
            new() { 0, 3, 6 },
            new() { 1, 4, 7 },
            new() { 2, 5, 8 },
            new() { 0, 1, 2 },
            new() { 3, 4, 5 },
            new() { 6, 7, 8 },
            new() { 0, 4, 8 },
            new() { 2, 4, 6 },
        };

        return winConditions.Any(CombinationCompleted);
    }

    private bool CombinationCompleted(List<int> indices)
    {
        return _data[indices[0]] == _data[indices[1]] && _data[indices[1]] == _data[indices[2]] &&
               (_data[indices[0]] == 'X' || _data[indices[0]] == 'O');
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