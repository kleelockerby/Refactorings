
namespace TicTacToe.Constants 
{
    public static class GameConstants
    {
        public const string StartGame = " -- Tic Tac Toe -- ";
        public const string BoardRow = " {0} | {1} | {2} ";
        public const string BoardSeparator = " ---+---+--- ";
        public const string DisplayPrompt = " > ";

        public const string DisplayEndWinner = "The winner is %PLAYER%";
        public const string DisplayEndNoWinner = "No one won.";

        //public const string AskMoveX = "What box do you want to place {playerX} in? (1-9)" + NewLine + displayPrompt;
        //public const string AskMoveY = "What box do you want to place {playerY} in? (1-9)" + NewLine + displayPrompt;
        public const string AskMove = "What box do you want to place %PLAYER% in? (1-9) ";

        public const string ErrorNotVacant = "Error: box not vacant!" + NewLine + "Press any key to try again..";
        public const string ErrorWrongSelection = "Wrong selection entered!" + NewLine + "Press any key to try again..";
        public const string NewLine = "\r\n"; 

        public const int MaxMoveCount = 9;
        public const int MinMoveCount = 0;
    }
}
