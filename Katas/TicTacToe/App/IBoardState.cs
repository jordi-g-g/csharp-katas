namespace Katas.TicTacToe.App;

public interface IBoardState
{
    bool IsGameOver();
    char[] GetData();
    void TakeField(int index, char player);
}