namespace TicTacToe.Providers 
{
    public interface IConsoleProvider
    {
        string Name { get; }
        ConsoleModel ConsoleModel { get; set; }
        void HandleConsole(CurrentPlayerType currentPlayer, string message = "");
    }
}
