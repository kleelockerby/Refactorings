#nullable disable warnings

namespace TicTacToe.Providers
{
    public class ErrorConsoleProvider : BaseConsoleProvider
    {
        public ErrorConsoleProvider() : base()
        {
            BuildConsoleInfo();
        }

        public override void HandleConsole()
        {
            string messageNewOrOrig = !string.IsNullOrEmpty(this.messageUpdated) ? this.messageUpdated : GameConsoleInfo.Message;
            string message = GameConsoleInfo.PrefixLNewLine ? GameConstants.NewLine + messageNewOrOrig : GameConsoleInfo.Message;
            Console.WriteLine(message);
            if (GameConsoleInfo.DisplayPrompt)
            {
                Console.Write(GameConstants.DisplayPrompt);
            }
        }

        private void BuildConsoleInfo()
        {
            GameConsoleInfo = new ConsoleInfo(GameConstants.ErrorWrongSelection, true, false);
        }
    }
}
