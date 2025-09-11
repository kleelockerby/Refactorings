namespace TicTacToe.Providers 
{
    public interface IConsoleProvider
    {
        string Name { get; }
        ConsoleInfo ConsoleInfo { get; set; }
        void HandleConsole();
        void Update(ConsoleInfo consoleInfo);
        PlayerStateContainer GetStateContainer();
        //bool IsProperProvider(ConsoleInfo consoleInfo);
        //string GetProviderType();
    }
}
