#nullable disable warnings

namespace TicTacToe.Providers
{
    public class EndConsoleProvider : ConsoleProviderBase, IConsoleProvider
    {
        public string Name { get; set; } = ConsoleType.End.ToString();

        public EndConsoleProvider()
        {
            this.ConsoleModel = new ConsoleModel(ConsoleType.End, string.Empty, true, true);
        }
    }
}