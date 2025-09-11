#nullable disable warnings
namespace TicTacToe.Providers
{
    public class StartConsoleProvider : ConsoleProviderBase, IConsoleProvider
    {
        public string Name { get; } = ConsoleType.Start.ToString();
        public ConsoleInfo ConsoleInfo { get; set; }

        public StartConsoleProvider(PlayerStateContainer playerState) : base(playerState)
        {
            ConsoleInfo = new ConsoleInfo(ConsoleType.Start, GameConstants.StartGame, false, true, false, true);
        }

        public void HandleConsole()
        {
            Console.WriteLine(ConsoleInfo?.Message);
            Thread.Sleep(2200);
            Console.Clear();
            Console.WriteLine(GameConstants.NewLine);
        }

        public void Update(ConsoleInfo info)
        {

        }
    }
}
