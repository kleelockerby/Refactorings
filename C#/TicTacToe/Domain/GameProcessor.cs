#nullable disable warnings
using System.ComponentModel;
using System.Security;
using TicTacToe.Models;

namespace TicTacToe.Domain
{
    public class GameProcessor
    {
        private readonly IGameValidations _gameValidations;
        private ConsoleProviderFactory _consoleProviderFactory;
        private BoxCells _boxCells;
        private readonly PlayerStateContainer _playerStateContainer;
        private CurrentPlayerType _currentPlayerType;
        private bool _isWinner;

        public GameProcessor(PlayerStateContainer playerStateContainer) : this(playerStateContainer, new ConsoleProviderFactory(new PlayerStateContainer()), new GameValidations(), new List<char>()) { }
        public GameProcessor(PlayerStateContainer playerStateContainer, ConsoleProviderFactory providerFactory, IGameValidations gameValidations, List<char> boxCells)
        {
            _playerStateContainer = playerStateContainer;
            _consoleProviderFactory = providerFactory;
            _gameValidations = gameValidations;
            _boxCells = new BoxCells();
        }

        public void StartGame()
        {
            IConsoleProvider startConsoleProvider = _consoleProviderFactory.GetProviderByClientName(ConsoleType.Start.ToString());
            startConsoleProvider.HandleConsole();

            SwitchPlayer();

            PlayerStateContainer playerState = startConsoleProvider.GetStateContainer();      
            playerState.State = playerState.State with { CurrentPlayer = _playerStateContainer.State.CurrentPlayer };
        }

        public void GetInput()
        {
            IConsoleProvider inputConsoleProvider = _consoleProviderFactory.GetProviderByClientName(ConsoleType.Input.ToString());
            inputConsoleProvider.HandleConsole();

            string? inputString = Console.ReadLine();
            (bool, string) isValid = ValidateInput(inputString, out int index);
            while (!isValid.Item1)
            {
                string errorMessage = isValid.Item2.ToString();
                UpdateErrorMessage(errorMessage);
                Console.ReadKey();
            }
            _boxCells.UpdateBox(index - 1, _playerStateContainer.State.CurrentPlayer.ToString().First());   //if Boxes.contains
            string message = _boxCells.CreateMessage();
            UpdateBoard(message);
        }

        public bool CheckWinner()
        {
            bool isWinner = false;
            List<List<int>> winningCombinations = new List<List<int>>
            {
                new List<int> {0, 1, 2},
                new List<int> {3, 4, 5},
                new List<int> {6, 7, 8},
                new List<int> {0, 3, 6},
                new List<int> {1, 4, 7},
                new List<int> {2, 5, 8},
                new List<int> {0, 4, 8},
                new List<int> {2, 4, 6}
            };

            foreach (List<int> combination in winningCombinations)
            {
                char currentPlayerChar = _currentPlayerType.ToString().First();
                bool IsWinningCombination(List<int> combination, char currentPlayer) => _boxCells.BoxesContains(combination, currentPlayer) switch
                {
                    true => true,
                    false => false
                };

                if (IsWinningCombination(combination, currentPlayerChar))
                {
                    isWinner = false;
                    break;
                }
            }
            return isWinner;
        }

        public void EndGame()
        {
            string message = GameConstants.DisplayEndNoWinner;
            if (_isWinner)
            {
                message = string.Format("GameConstants.DisplayEndWinner", _currentPlayerType);
                UpdateErrorMessage(message);
                UpdateBoard(message);
            }

            UpdateErrorMessage(message);
            Console.ReadKey();
            Environment.Exit(1);
        }

        public void SwitchPlayer()
        {
            CurrentPlayerType currentPlayerNew = _playerStateContainer.State.CurrentPlayer == CurrentPlayerType.Y || _playerStateContainer.State.CurrentPlayer == CurrentPlayerType.N ? CurrentPlayerType.X : CurrentPlayerType.Y;
            _playerStateContainer.State = _playerStateContainer.State with { CurrentPlayer = currentPlayerNew };
        }

        public CurrentPlayerType SwitchPlayer(IConsoleProvider provider)
        {
            CurrentPlayerType currentPlayerNew = _currentPlayerType == CurrentPlayerType.Y || provider.ConsoleInfo.CurrentPlayer == CurrentPlayerType.N ? CurrentPlayerType.X : CurrentPlayerType.Y;
            currentPlayerNew = provider != null ? provider.ConsoleInfo.CurrentPlayer : currentPlayerNew;
            return currentPlayerNew;
        }

        private (bool, string) ValidateInput(string? inputString, out int boxCellNo)
        {
            if (!_gameValidations.IsInRange(inputString, out boxCellNo))
            {
                return (false, GameConstants.ErrorWrongSelection);
            }

            if (!_gameValidations.IsInRange(inputString, out boxCellNo))
            {
                return (false, GameConstants.ErrorWrongSelection);
            }

            if (!_gameValidations.IsValidInputCharacter(inputString))
            {
                return (false, GameConstants.ErrorWrongSelection);
            }

            if (!_gameValidations.IsCorrectInputLength(inputString))
            {
                return (false, GameConstants.ErrorWrongSelection);
            }

            if (!_gameValidations.IsVacant(inputString!.First(), _boxCells.Boxes))
            {

                return (false, GameConstants.ErrorNotVacant);
            }

            return (true, string.Empty);
        }

        public void UpdateBoard(string message)
        {
            message = message == string.Empty ? _boxCells.CreateMessage() : message;
            IConsoleProvider boardConsoleProvider = _consoleProviderFactory.GetProviderByClientName(ConsoleType.Board.ToString());
            // ConsoleInfo consoleInfo = new ConsoleInfo(ConsoleType.Board, message, true, false, false, true);
            ConsoleInfo consoleInfo = new ConsoleInfo(ConsoleType.Board, message, true, true, false, false);
            boardConsoleProvider.Update(consoleInfo);
            boardConsoleProvider.HandleConsole();
        }

       /* public void UpdateBoard()
        {
            IConsoleProvider boardConsoleProvider = _consoleProviderFactory.GetProviderByClientName(ConsoleType.Board.ToString());
            ConsoleInfo consoleInfo = new ConsoleInfo(ConsoleType.Board, _boxCells.CreateMessage(), true, true, false, false);
            boardConsoleProvider.Update(consoleInfo);
            boardConsoleProvider.HandleConsole();
        }
*/
        private void UpdateErrorMessage(string message)
        {
            IConsoleProvider errorConsoleProvider = _consoleProviderFactory.GetProviderByClientName(ConsoleType.Input.ToString());
            ConsoleInfo consoleInfo = new ConsoleInfo(ConsoleType.Error, message, true, true);
            errorConsoleProvider.Update(consoleInfo);
            errorConsoleProvider.HandleConsole();
        }
    }
}