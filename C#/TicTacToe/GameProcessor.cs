#nullable disable warnings
namespace TicTacToe
{
    public class GameProcessor
    {
        private readonly IGameValidations _gameValidations;
        private readonly IPlayerStateContainer _playerStateContainer;
        private readonly ConsoleProviderFactory _consoleProviderFactory;
        private BoxModel _boxes = new BoxModel();

        public GameProcessor() : this(new ConsoleProviderFactory(), new PlayerStateContainer(), new GameValidations()) { }

        public GameProcessor(ConsoleProviderFactory consoleProviderFactory, IPlayerStateContainer playerStateContainer, IGameValidations gameValidations)
        {
            _playerStateContainer = playerStateContainer;
            _gameValidations = gameValidations;
            _consoleProviderFactory = new ConsoleProviderFactory();
        }

        public void StartGame()
        {
            PrintConsole(ConsoleType.Start, GameConstants.StartGame);
        }

        public void GetInput()
        {
            PrintConsole(ConsoleType.Input, string.Format(GameConstants.AskMove, _playerStateContainer.State.CurrentPlayer.ToString()));

            string? inputString = Console.ReadLine();
            (bool, string) isValid = ValidateInput(inputString, out int index);

            if (!isValid.Item1)
            {
                PrintConsole(ConsoleType.Error, isValid.Item2);
                Console.ReadKey();
                GetInput();
            }
            else
            {
                UpdateBoard(index);
            }
        }

        public bool CheckWinner()
        {
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
                char currentPlayerChar = _playerStateContainer.State.CurrentPlayer.ToString().First();

                bool IsWinningCombination(List<int> combination, char currentPlayer) => _boxes.BoxesContains(combination, currentPlayer) switch
                {
                    true => true,
                    false => false
                };

                if (IsWinningCombination(combination, currentPlayerChar))
                {
                    _playerStateContainer.State = _playerStateContainer.State with { IsWinner = true, WinPlayer = _playerStateContainer.State.CurrentPlayer };
                    break;
                }
            }
            return _playerStateContainer.State.IsWinner;
        }

        public void EndGame()
        {
            string message = GameConstants.DisplayEndNoWinner;

            if (_playerStateContainer.State.IsWinner)
            {
                message = string.Format(GameConstants.DisplayEndWinner, _playerStateContainer.State.WinPlayer.ToString());

            }
            PrintConsole(ConsoleType.End, message);

            Console.ReadKey();
            if (message == GameConstants.DisplayEndNoWinner)
            {
                Environment.Exit(1);
            }
        }

        public void SwitchPlayer()
        {
            CurrentPlayerType currentPlayerNew = _playerStateContainer.State.CurrentPlayer == CurrentPlayerType.Y || _playerStateContainer.State.CurrentPlayer == CurrentPlayerType.N ? CurrentPlayerType.X : CurrentPlayerType.Y;
            _playerStateContainer.State = _playerStateContainer.State with { CurrentPlayer = currentPlayerNew };
        }

        public void PrintBoard()
        {
            string message = _boxes.CreateMessage();
            PrintConsole(ConsoleType.Board, message);
        }

        public bool GetWinner()
        {
            return _playerStateContainer.State.IsWinner;
        }

        private void UpdateBoard(int index)
        {
            _boxes.UpdateBox(index - 1, _playerStateContainer.State.CurrentPlayer.ToString().First());
        }

        private (bool, string) ValidateInput(string? inputString, out int boxCellNo)
        {
            if (!_gameValidations.IsInRange(inputString, out boxCellNo))
            {
                return (false, GameConstants.ErrorWrongSelection);
            }

            if (!_gameValidations.IsCorrectInputLength(inputString))
            {
                return (false, GameConstants.ErrorWrongSelection);
            }

            if (!_gameValidations.IsVacant(boxCellNo - 1, _boxes))
            {
                return (false, GameConstants.ErrorNotVacant);
            }

            return (true, string.Empty);
        }

        private void PrintConsole(ConsoleType consoleType, string message)
        {
            IConsoleProvider consoleProvider = _consoleProviderFactory.GetProviderByClientName(consoleType.ToString());
            consoleProvider.HandleConsole(_playerStateContainer.State.CurrentPlayer, message);
        }
    }
}