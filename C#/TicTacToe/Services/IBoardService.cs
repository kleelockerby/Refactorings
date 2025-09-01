namespace TicTacToe.Services
{
    public interface IBoardService
    {
        List<char> Boxes { get; }
        void UpdateBox(int index, char currentPlayerChar);
        bool BoxesContains(int boxNo);
        bool BoxesContains(List<int> boxNos, char player);
        void PrintBoard();
    }
}
