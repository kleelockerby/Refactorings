namespace TicTacToe.Models
{
    public record GameInfo(CurrentPlayerType CurrentPlayer, CurrentPlayerType WinPlayer, bool IsWinner, List<char> BoxCells, string ErrorMessage)
    {
        
    }
}
