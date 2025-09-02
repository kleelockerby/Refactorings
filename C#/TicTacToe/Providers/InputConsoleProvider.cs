#nullable disable warnings
namespace TicTacToe.Providers 
{
    public class InputConsoleProvider : BaseConsoleProvider
    {
        public InputConsoleProvider() : base()
        {
            BuildConsoleInfo();
        }

        public override void HandleConsole()
        {
            if(GameConsoleInfo.ClearConsole)
            {
                Console.Clear();
            }
            string message = GameConsoleInfo.PrefixLNewLine ? GameConstants.NewLine + GameConsoleInfo.Message : GameConsoleInfo.Message;
            Console.WriteLine(message);
            if (GameConsoleInfo.DisplayPrompt)
            {
                Console.Write(GameConstants.DisplayPrompt);
            }
        }

        private void BuildConsoleInfo()
        {
            GameConsoleInfo = new ConsoleInfo(string.Format(GameConstants.AskMove, AppState.CurrentPlayer.ToString()), true, true);
        }
    }
}