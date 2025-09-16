#nullable disable warnings
namespace TicTacToe.Providers
{
    public class ConsoleProviderBase
    {
        public ConsoleModel ConsoleModel { get; set; }

        public virtual void HandleConsole(CurrentPlayerType currentPlayer, string message)
        {
            if (ConsoleModel.ClearConsole)
            {
                Console.Clear();
            }
            ConsoleModel.Message = ConsoleModel.PrefixLNewLine ? GameConstants.NewLine + message : message;
            Console.WriteLine(ConsoleModel.Message);
            if (ConsoleModel.DisplayPrompt)
            {
                Console.Write(GameConstants.DisplayPrompt);
            }
        }
    }
}
