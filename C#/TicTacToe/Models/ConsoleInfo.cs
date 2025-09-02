namespace TicTacToe.Models
{
    public class ConsoleInfo
    {
        public string Message { get; } = string.Empty;
        public bool PrefixLNewLine { get; }
        public bool ClearConsole { get; }
        public bool DisplayPrompt { get; }
        public bool SleepConsole { get; }

        public ConsoleInfo(string message, bool prefixLineFeed)
        {
            this.Message = message;
            this.PrefixLNewLine = prefixLineFeed;
        }

        public ConsoleInfo(string message, bool prefixLineFeed, bool clearConsole, bool displayPrompt = false, bool sleepConsole = false)
        {
            this.Message = message;
            this.PrefixLNewLine = prefixLineFeed;
            this.ClearConsole = clearConsole;
            this.DisplayPrompt = displayPrompt;
            this.SleepConsole = sleepConsole;
        }
    }
}
