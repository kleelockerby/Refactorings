namespace TicTacToe.Domain
{
    public class ConsoleProviderCommands
    {
        public static IConsoleProvider StartProvider = new StartConsoleProvider();
        public static IConsoleProvider InputProvider = new InputConsoleProvider();
        public static IConsoleProvider ErrorProvider = new ErrorConsoleProvider();
        public static IConsoleProvider BoardProvider = new BoardConsoleProvider();
        public static IConsoleProvider EndProvider = new EndConsoleProvider();

        public static ConsoleHandler GetProvider(ConsoleType consoleType, out IConsoleProvider provider)
        {
            ConsoleHandler consoleHandler;
            provider = StartProvider;
            switch (consoleType)
            {
                case ConsoleType.Start:
                    provider = StartProvider;
                    consoleHandler = new ConsoleHandler(StartProvider);
                    break;
                case ConsoleType.Error:
                    provider = ErrorProvider;
                    consoleHandler = new ConsoleHandler(ErrorProvider);
                    break;
                case ConsoleType.Board:
                    provider = BoardProvider;
                    consoleHandler = new ConsoleHandler(BoardProvider);
                    break;
                case ConsoleType.End:
                    provider = EndProvider;
                    consoleHandler = new ConsoleHandler(EndProvider);
                    break;
                case ConsoleType.Input:
                    provider = InputProvider;
                    consoleHandler = new ConsoleHandler(InputProvider);
                    break;
            }
            return new ConsoleHandler(provider);
        }
    }
}
