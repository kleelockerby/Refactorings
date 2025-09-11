namespace TicTacToe.Models
{
    public record PlayerState(CurrentPlayerType CurrentPlayer, CurrentPlayerType WinPlayer, bool IsWinner);

    public class PlayerStateContainer
    {
        public PlayerState State { get; set; } = new PlayerState(CurrentPlayerType.N, CurrentPlayerType.N, false);
    }
}