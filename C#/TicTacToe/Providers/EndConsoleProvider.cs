#nullable disable warnings

namespace TicTacToe.Providers
{
    public class EndConsoleProvider : BaseConsoleProvider
    {
        public EndConsoleProvider() : base()
        {
            BuildConsoleInfo();
        }

        public override void HandleConsole()
        {
            // string message = (bool)AppState.IsWinner ? string.Format(GameConstants.DisplayEndWinner, AppState.WinPlayer.ToString()) : GameConstants.DisplayEndNoWinner;
            string message = GameConsoleInfo.Message;
            if (GameConsoleInfo.ClearConsole)
            {
                Console.Clear();
            }
            message = GameConsoleInfo.PrefixLNewLine ? GameConstants.NewLine + message : message;
            Console.WriteLine(message);
            if (GameConsoleInfo.DisplayPrompt)
            {
                Console.Write(GameConstants.DisplayPrompt);
            }
        }

        private void BuildConsoleInfo()
        {
            GameConsoleInfo = new ConsoleInfo(GameConstants.DisplayEndNoWinner, true, false);
        }
    }
}