using TicTacToe.Providers;

namespace TicTacToe.Domain
{
    public class ConsoleHandler
    {
        private readonly IConsoleProvider _consoleProvider;

        public ConsoleHandler(IConsoleProvider consoleStrategy)
        {
            _consoleProvider = consoleStrategy;
        }

        public void HandleConsole()
        {
            _consoleProvider.HandleConsole();
        }
    }
}
