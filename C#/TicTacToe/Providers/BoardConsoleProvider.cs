#nullable disable warnings
using System.Text;

namespace TicTacToe.Providers
{
    public class BoardConsoleProvider : ConsoleProviderBase, IConsoleProvider
    {
        public string Name { get; set; } = ConsoleType.Board.ToString();
        public BoardConsoleProvider()
        {
            this.ConsoleModel = new ConsoleModel(ConsoleType.Board, string.Empty, false, false, true);
        }

        public override void HandleConsole(CurrentPlayerType currentPlayer, string message)
        {
            this.ConsoleModel.Message = message;
            if (ConsoleModel.ClearConsole)
            {
                Console.Clear();
            }
            Console.WriteLine(ConsoleModel.Message);
        }
    }
}
