namespace TicTacToe
{
    public class GameProcessor
    {
        private readonly IBoardService _boardService;
        private readonly IGameValidations _gameValidations;
        private bool _IsWinner = false;
        private CurrentPlayer _currentPlayer = CurrentPlayer.N;
        private CurrentPlayer _winPlayer = CurrentPlayer.N;
        private int _currentMoveCount = 0;

        public GameProcessor() : this(new BoardService(new List<char> { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }), new GameValidations()) { }
        public GameProcessor(IBoardService boardService, IGameValidations gameValidations)
        {
            _boardService = boardService ?? throw new ArgumentNullException(nameof(boardService));
            _gameValidations = gameValidations ?? throw new ArgumentNullException(nameof(gameValidations));
        }

        public void StartGame()
        {
            PrintMessage(GameConstants.StartGame, ClearConsoleType.ClearAndSleep);
            SwitchPlayer();
            PlayGame();
        }

        private void PlayGame()
        {
            while (_currentMoveCount < GameConstants.MaxMoveCount)
            {
                _boardService.PrintBoard();
                PrintMessage(GameConstants.AskMove.Replace("%PLAYER%", _currentPlayer.ToString()), true, true);
                GetInput();
                CheckWinner();
                if (_IsWinner)
                {
                    break;
                }
                _currentMoveCount++;
                SwitchPlayer();
            }
            EndGame();
        }

        private void GetInput()
        {
            string? inputString = Console.ReadLine();
            (bool, string) isValid = ValidateInput(inputString, out int index);
            if (!isValid.Item1)
            {
                PrintMessage(isValid.Item2, true, false);
                Console.ReadKey();
                GetInput();
            }
            UpdateBoard(index);
        }

        private (bool, string) ValidateInput(string? inputString, out int index)
        {
            if (!_gameValidations.IsInRange(inputString, out index))
            {
                return (false, GameConstants.ErrorWrongSelection);
            }

            if (!_gameValidations.isCorrectInputLength(inputString))
            {
                return (false, GameConstants.ErrorWrongSelection);
            }

            if (!_gameValidations.IsVacant(inputString!.First(), _boardService.Boxes))
            {
                return (false, GameConstants.ErrorNotVacant);
            }

            return (true, string.Empty);
        }

        private void SwitchPlayer() => _currentPlayer = _currentPlayer == CurrentPlayer.Y || _currentPlayer == CurrentPlayer.N ? CurrentPlayer.X : CurrentPlayer.Y;

        private void UpdateBoard(int position) => _boardService.UpdateBox(position - 1, _currentPlayer.ToString().First());

        private void CheckWinner()
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
                char currentPlayerChar = _currentPlayer.ToString().First();
                if (IsWinningCombination(combination, currentPlayerChar))
                {
                    _IsWinner = true;
                    _winPlayer = _currentPlayer;
                    break;
                }
            }
        }

        private void EndGame()
        {
            string message = GameConstants.DisplayEndNoWinner;
            if (_IsWinner)
            {
                _boardService.PrintBoard();
                message = GameConstants.DisplayEndWinner.Replace("%PLAYER%", _winPlayer.ToString());
            }
            PrintMessage(message, true, false);
            Console.ReadKey();
            Environment.Exit(1);
        }

        private bool IsWinningCombination(List<int> combination, char currentPlayer) => _boardService.BoxesContains(combination, currentPlayer) switch
         {
             true => true,
             false => false
         };

        private void PrintMessage(string message, ClearConsoleType clearConsoleType)
        {
            Console.WriteLine(message + GameConstants.NewLine);
            if (clearConsoleType == ClearConsoleType.ClearAndSleep)
            {
                Thread.Sleep(1200);
            }
            Console.Clear();
            Console.WriteLine(GameConstants.NewLine);
        }

        private void PrintMessage(string message, bool precedingNewLine, bool diplayPrompt, bool clearConsole = false)
        {
            if (clearConsole)
            {
                Console.Clear();
            }
            message = precedingNewLine ? GameConstants.NewLine + message : message;
            Console.WriteLine(message);
            if (diplayPrompt)
            {
                Console.Write(GameConstants.DisplayPrompt);
            }
        }
    }
}