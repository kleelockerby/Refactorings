#nullable disable warnings

using System.Diagnostics.Metrics;
using TicTacToe.Models;

namespace TicTacToe.Providers
{
    public class ErrorConsoleProvider : ConsoleProviderBase, IConsoleProvider
    {
        public string Name { get; set; } = ConsoleType.Error.ToString();

        public ErrorConsoleProvider()
        {
            this.ConsoleModel = new ConsoleModel(ConsoleType.Error, string.Empty, true, true);
        }

        public override void HandleConsole(CurrentPlayerType currentPlayer, string message)
        {
            if (ConsoleModel.ClearConsole)
            {
                Console.Clear();
            }
            this.ConsoleModel.Message = ConsoleModel.PrefixLNewLine ? GameConstants.NewLine + message : message;
            Console.WriteLine(message);
            if (ConsoleModel.DisplayPrompt)
            {
                Console.Write(GameConstants.DisplayPrompt);
            }
        }
    }
}
