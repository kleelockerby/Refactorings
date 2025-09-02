#nullable disable warnings
using System.ComponentModel;

namespace TicTacToe.Domain
{
    public class GameProcessor
    {
        private readonly IBoardService _boardService;
        private readonly IGameValidations _gameValidations;

        public List<char> Boxes { get; }

        public IAppState AppState = new AppState(CurrentPlayerType.N, CurrentPlayerType.N, false,
            new List<char> { GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty },
            string.Empty );

       /* private CurrentPlayerType? lastCurrentPlayer;
        private CurrentPlayerType? lastWinPlayer;
        private bool? lastIsWinner;
        private List<char> lastBoxCellNos;
        private string lastErrorMessage;*/

        public GameProcessor() : this(new BoardService(), new GameValidations()) { }
        public GameProcessor(IBoardService boardService, IGameValidations gameValidations)
        {
            _boardService = boardService;
            _gameValidations = gameValidations;
           AppState.PropertyChanged += _appState_PropertyChanged;
        }

        public void StartGame(ConsoleHandler startHandler)
        {
            startHandler.HandleConsole();
            SwitchPlayer();
        }

        public void DrawBoard(ConsoleHandler boardHandler, ConsoleHandler inputHandler)
        {
            boardHandler.HandleConsole();
            inputHandler.HandleConsole();
            //_boardService.PrintBoard();
        }

        public void GetInput(ConsoleHandler errorHandler, IConsoleProvider errorProvider)
        {
            string? inputString = Console.ReadLine();

            (bool, string) isValid = ValidateInput(inputString, out int boxCellNo);
            while (!isValid.Item1)
            {
                errorProvider.SetErrorMessage(isValid.Item2);
                errorHandler.HandleConsole();
                Console.ReadKey();
            }
            UpdateBoard(boxCellNo);
        }

        public void SwitchPlayer()
        {
           CurrentPlayerType currentPlayerNew = AppState.CurrentPlayer == CurrentPlayerType.Y || AppState.CurrentPlayer == CurrentPlayerType.N ? CurrentPlayerType.X : CurrentPlayerType.Y;
           AppState.CurrentPlayer = currentPlayerNew;
        }

        public void CheckWinner()
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
                char currentPlayerChar = AppState.CurrentPlayer.ToString().First();
                bool IsWinningCombination(List<int> combination, char currentPlayer) => _boardService.BoxesContains(combination, currentPlayer) switch
                {
                    true => true,
                    false => false
                };

                if (IsWinningCombination(combination, currentPlayerChar))
                {
                    AppState.IsWinner = true;
                    AppState.WinPlayer = AppState.CurrentPlayer;
                    break;
                }
            }
        }

        public void EndGame(ConsoleHandler boardHandler, ConsoleHandler endHandler, IConsoleProvider endProvider)
        {
            string message = GameConstants.DisplayEndNoWinner;
            if ((bool)AppState.IsWinner)
            {
                boardHandler.HandleConsole();
                message = string.Format("GameConstants.DisplayEndWinner", AppState.WinPlayer);
            }
            endProvider.SetErrorMessage(message);
            endProvider.HandleConsole();
            Console.ReadKey();
            Environment.Exit(1);
        }

        private void UpdateBoard(int position) => _boardService.UpdateBox(position - 1, AppState.CurrentPlayer.ToString().First());

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

            if (!_gameValidations.IsVacant(inputString!.First(), _boardService.Boxes))
            {
                return (false, GameConstants.ErrorNotVacant);
            }

            return (true, string.Empty);
        }
    
    }
}
