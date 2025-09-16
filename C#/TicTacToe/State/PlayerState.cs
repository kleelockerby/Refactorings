namespace TicTacToe.State
{
    public record PlayerState(CurrentPlayerType CurrentPlayer, CurrentPlayerType WinPlayer, bool IsWinner);

    public interface IPlayerStateContainer
    {
        PlayerState State { get; set; }
    }

    public class PlayerStateContainer : IPlayerStateContainer
    {
        public PlayerState State { get; set; } = new PlayerState(CurrentPlayerType.N, CurrentPlayerType.N, false);
    }
}