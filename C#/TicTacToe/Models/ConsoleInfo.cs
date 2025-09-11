namespace TicTacToe.Models
{
    public record ConsoleInfo
    {
        public ConsoleType GameConsoleType { get; init; }
        public CurrentPlayerType CurrentPlayer { get; set; }
        public string Message { get; } = string.Empty;
        public bool PrefixLNewLine { get; }
        public bool ClearConsole { get; }
        public bool DisplayPrompt { get; }
        public bool SleepConsole { get; }

        public ConsoleInfo(ConsoleType consoleType, string message, bool prefixLineFeed, CurrentPlayerType currentPlayer = CurrentPlayerType.N)
        {
            this.GameConsoleType = consoleType;
            this.CurrentPlayer = currentPlayer;
            this.Message = message;
            this.PrefixLNewLine = prefixLineFeed;
        }

        public ConsoleInfo(ConsoleType consoleType, string message, bool prefixLineFeed, bool clearConsole, bool displayPrompt = false, bool sleepConsole = false, CurrentPlayerType currentPlayer = CurrentPlayerType.N)
        {
            this.GameConsoleType = consoleType;
            this.CurrentPlayer = currentPlayer;
            this.Message = message;
            this.PrefixLNewLine = prefixLineFeed;
            this.ClearConsole = clearConsole;
            this.DisplayPrompt = displayPrompt;
            this.SleepConsole = sleepConsole;
        }
    }
}
