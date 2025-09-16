namespace TicTacToe.Models
{
    public record ConsoleModel
    {
        public ConsoleType GameConsoleType { get; init; }
        public string Message { get; set; } = string.Empty;
        public bool PrefixLNewLine { get; }
        public bool DisplayPrompt { get; }
        public bool ClearConsole { get; }
        public bool SleepConsole { get; }

        public ConsoleModel(ConsoleType consoleType, string message, bool prefixLineFeed, bool displayPrompt = false, bool clearConsole = false, bool sleepConsole = false)
        {
            this.GameConsoleType = consoleType;
            this.Message = message;
            this.PrefixLNewLine = prefixLineFeed;
            this.ClearConsole = clearConsole;
            this.DisplayPrompt = displayPrompt;
            this.SleepConsole = sleepConsole;
        }
    }
}
