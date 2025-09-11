#nullable disable warnings
namespace TicTacToe.Providers 
{
    public class InputConsoleProvider : ConsoleProviderBase, IConsoleProvider
    {
        public string Name { get; } = ConsoleType.Input.ToString();
        public ConsoleInfo ConsoleInfo { get; set; }

        public InputConsoleProvider(PlayerStateContainer playerState) : base(playerState)
        {
            ConsoleInfo = new ConsoleInfo(ConsoleType.Input, string.Format(GameConstants.AskMove, PlayerStateContainer.State.CurrentPlayer.ToString()), true, false, true, false);
        }

        public void HandleConsole()
        {
            if (ConsoleInfo.ClearConsole)
            {
                Console.Clear();
            }
            string message = ConsoleInfo.PrefixLNewLine ? GameConstants.NewLine + ConsoleInfo.Message : ConsoleInfo.Message;
            Console.WriteLine(message);
            if (ConsoleInfo.DisplayPrompt)
            {
                Console.Write(GameConstants.DisplayPrompt);
            }
        }
       
        public void Update(ConsoleInfo info)
        {
          
        }
    }
}