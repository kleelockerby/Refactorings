#nullable disable warnings

namespace TicTacToe.Providers
{
    public class ErrorConsoleProvider : ConsoleProviderBase, IConsoleProvider
    {
        public string Name { get; } = ConsoleType.Error.ToString();
        public ConsoleInfo ConsoleInfo { get; set; }

        public ErrorConsoleProvider(PlayerStateContainer playerState) : base(playerState)
        {
            ConsoleInfo = new ConsoleInfo(ConsoleType.Error, string.Empty, false, true, false, true);
        }

        public void HandleConsole()
        {
            if (ConsoleInfo.ClearConsole)
            {
                Console.Clear();
            }
            string message = ConsoleInfo.PrefixLNewLine ? GameConstants.NewLine + ConsoleInfo.Message : ConsoleInfo.Message;
            Console.WriteLine(message);
            if (ConsoleInfo.DisplayPrompt)
            {
                Console.Write(GameConstants.DisplayPrompt);
            }
        }

        public void Update(ConsoleInfo consoleInfo)
        {
            ConsoleInfo = consoleInfo;
        }
    }
}
