#nullable disable warnings

using System.Text;

namespace TicTacToe.Providers
{
    public class BoardConsoleProvider : ConsoleProviderBase, IConsoleProvider
    {
        public string Name { get; } = ConsoleType.Board.ToString();
        public ConsoleInfo ConsoleInfo { get; set; }

        public BoardConsoleProvider(PlayerStateContainer playerState) : base(playerState)
        {
            string message = CreateBoard();
            ConsoleInfo = new ConsoleInfo(ConsoleType.Board, message, false, true, false, true);
        }

        public void HandleConsole()
        {
            if (ConsoleInfo.ClearConsole)
            {
                Console.Clear();
            }
            Console.WriteLine(ConsoleInfo.Message);
        }

        public void Update(ConsoleInfo consoleInfo)
        {
            this.ConsoleInfo = consoleInfo;
            HandleConsole();
        }

        private string CreateBoard()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(GameConstants.BoardRow + GameConstants.NewLine + GameConstants.BoardSeparator, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty));
            sb.AppendLine(string.Format(GameConstants.BoardRow + GameConstants.NewLine + GameConstants.BoardSeparator, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty));
            sb.AppendLine(string.Format(GameConstants.BoardRow + GameConstants.NewLine + GameConstants.BoardSeparator, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty));
            return sb.ToString();
        }
    }
}
