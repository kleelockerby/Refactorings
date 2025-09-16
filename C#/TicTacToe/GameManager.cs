#nullable disable warnings
namespace TicTacToe
{
    public class GameManager
    {
        private GameProcessor gameProcessor;
        private int currentMoveCount = 0;

        public GameManager()
        {
            gameProcessor = new GameProcessor();
        }

        public void PlayGame()
        {
            gameProcessor.StartGame();
            gameProcessor.SwitchPlayer();

            while (currentMoveCount < GameConstants.MaxMoveCount)
            {
                gameProcessor.PrintBoard();
                gameProcessor.GetInput();
                bool isWinner = gameProcessor.CheckWinner();
                if (isWinner)
                {
                    break;
                }
                currentMoveCount++;
                gameProcessor.SwitchPlayer();
            }
            gameProcessor.EndGame();
        }
    }
}