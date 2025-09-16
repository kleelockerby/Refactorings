#nullable disable warnings
namespace TicTacToe.Providers
{
    public class InputConsoleProvider : ConsoleProviderBase, IConsoleProvider
    {
        public string Name { get; set; } = ConsoleType.Input.ToString();

        public InputConsoleProvider()
        {
            this.ConsoleModel = new ConsoleModel(ConsoleType.Input, string.Empty, true, true);
        }
    }
}