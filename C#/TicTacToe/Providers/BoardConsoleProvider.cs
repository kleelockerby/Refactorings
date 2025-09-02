#nullable disable warnings

using TicTacToe.Constants;

namespace TicTacToe.Providers 
{
    public class BoardConsoleProvider : BaseConsoleProvider
    {
        public BoardConsoleProvider() : base()
        {
            BuildConsoleInfo();
        }

        /*public override void HandleConsole()
        {
            Console.Clear();
            Console.WriteLine(GameConstants.BoardRow + GameConstants.NewLine + GameConstants.BoardSeparator, AppState.BoxCells[0], AppState.BoxCells[1], AppState.BoxCells[2]);
            Console.WriteLine(GameConstants.BoardRow + GameConstants.NewLine + GameConstants.BoardSeparator, AppState.BoxCells[3], AppState.BoxCells[4], AppState.BoxCells[5]);
            Console.WriteLine(GameConstants.BoardRow + GameConstants.NewLine + GameConstants.BoardSeparator + GameConstants.NewLine, AppState.BoxCells[6], AppState.BoxCells[7], AppState.BoxCells[8]);
        }*/

        public override void HandleConsole()
        {
            Console.Clear();
            Console.WriteLine(GameConstants.BoardRow + GameConstants.NewLine + GameConstants.BoardSeparator, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty);
            Console.WriteLine(GameConstants.BoardRow + GameConstants.NewLine + GameConstants.BoardSeparator, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty);
            Console.WriteLine(GameConstants.BoardRow + GameConstants.NewLine + GameConstants.BoardSeparator, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty);
        }

        private void BuildConsoleInfo()
        {
            GameConsoleInfo = new ConsoleInfo(string.Empty, false, true);
        }
    }
}
