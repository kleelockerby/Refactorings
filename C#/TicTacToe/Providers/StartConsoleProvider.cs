#nullable disable warnings
namespace TicTacToe.Providers
{
    public class StartConsoleProvider : ConsoleProviderBase, IConsoleProvider
    {
        public string Name { get; } = ConsoleType.Start.ToString();

        public StartConsoleProvider()
        {
            this.ConsoleModel = new ConsoleModel(ConsoleType.Start, string.Empty, true, true);
        }

        public override void HandleConsole(CurrentPlayerType currentPlayer, string message)
        {
            this.ConsoleModel.Message = GameConstants.StartGame;
            Console.WriteLine(ConsoleModel?.Message);
            Thread.Sleep(1200);
            Console.Clear();
            Console.WriteLine(GameConstants.NewLine);
        }
    }
}
