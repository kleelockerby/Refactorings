#nullable disable warnings

namespace TicTacToe.Providers
{
    public class EndConsoleProvider : ConsoleProviderBase, IConsoleProvider
    {
        public string Name { get; } = ConsoleType.End.ToString();
        public ConsoleInfo ConsoleInfo { get; set; }

        public EndConsoleProvider(PlayerStateContainer playerState) : base(playerState)
        {
            ConsoleInfo = new ConsoleInfo(ConsoleType.End, string.Empty, false, true, false, true);
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


        /* public override void HandleConsole()
         {
             // string message = (bool)AppState.IsWinner ? string.Format(GameConstants.DisplayEndWinner, AppState.WinPlayer.ToString()) : GameConstants.DisplayEndNoWinner;
             string message = GameConsoleInfo.Message;
             if (GameConsoleInfo.ClearConsole)
             {
                 Console.Clear();
             }
             message = GameConsoleInfo.PrefixLNewLine ? GameConstants.NewLine + message : message;
             Console.WriteLine(message);
             if (GameConsoleInfo.DisplayPrompt)
             {
                 Console.Write(GameConstants.DisplayPrompt);
             }
         }

         private void BuildConsoleInfo()
         {
             GameConsoleInfo = new ConsoleInfo(GameConstants.DisplayEndNoWinner, true, false);
         }*/
    }
}