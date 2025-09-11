#nullable disable warnings
using System.ComponentModel;
using System.Security.Cryptography;
using TicTacToe.Models;

namespace TicTacToe.Domain
{
    public class GameManager
    {
        private GameProcessor gameProcessor;
        private int currentMoveCount = 0;

        public GameManager()
        {
            gameProcessor = new GameProcessor(new PlayerStateContainer());
        }

        public void PlayGame()
        {
            gameProcessor.StartGame();

            while (currentMoveCount < GameConstants.MaxMoveCount)
            {
                gameProcessor.UpdateBoard(string.Empty);
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