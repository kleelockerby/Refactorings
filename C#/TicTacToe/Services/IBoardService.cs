namespace TicTacToe.Services
{
    public interface IBoardService
    {
        void UpdateBox(int index, char currentPlayerChar);
        bool BoxesContains(int boxNo);
        bool BoxesContains(int boxNo, char player);
        void PrintBoard();
    }
}
