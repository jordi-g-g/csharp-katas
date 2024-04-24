namespace Katas.TicTacToe.App;

public interface IBoardState
{
    bool IsFull();

    char[] GetData();
}