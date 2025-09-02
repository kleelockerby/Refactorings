namespace TicTacToe.Providers 
{
    public interface IConsoleProvider
    {
        ConsoleInfo? GameConsoleInfo { get; set; }
        void SetErrorMessage(string errorMessage);
        void HandleConsole();
    }
}
