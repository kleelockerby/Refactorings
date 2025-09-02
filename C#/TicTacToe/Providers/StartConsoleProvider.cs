using System.Threading;

namespace TicTacToe.Providers
{
    public class StartConsoleProvider : BaseConsoleProvider
    {
        public StartConsoleProvider() : base()
        {
            BuildConsoleInfo();
        }

        public override void HandleConsole()
        {
            Console.WriteLine(GameConsoleInfo?.Message);
            Thread.Sleep(1200);
            Console.Clear();
            Console.WriteLine(GameConstants.NewLine);
        }

        private void BuildConsoleInfo()
        {
            GameConsoleInfo = new ConsoleInfo(GameConstants.StartGame, false, true, false, true);
        }
    }
}
