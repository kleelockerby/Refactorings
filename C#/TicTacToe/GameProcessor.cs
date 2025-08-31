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

            /*
             //TooDo:
             ? Get rid of currentPlayer None
            Overloads for PrintMessage or Message class or MessageBuilder
            
            ? CheckWinner switch expression

            Unit Tests
            Custom Exception in Board Class
            Make Board Immutable
            PredicateBuilder - IsValidInput
            Create DI for Board
            Can anything be extension method?
            Update Readme

            public static float ValidAndParsePositiveFloat(string i_StringForValidation)
            {
                float parsedFloat = 0;
                bool isFloat = float.TryParse(i_StringForValidation, out parsedFloat);

                if (!isFloat || parsedFloat < 0)
                {
                    throw new FormatException("Invalid answer- only a positive number is allowed");
                }

                return parsedFloat;
            }


            private readonly Dictionary<string, Passenger> _bookedSeats = new();
            public IReadOnlyDictionary<string, Passenger> CurrentBookings => _bookedSeats.AsReadOnly();

            private readonly List<IFlightInfo> _flights = new();

            public IEnumerable<IFlightInfo> GetAllFlights()
            {
                return _flights.AsReadOnly();
            }

            private void DisplayBoardingHeader()

            public string BuildMessage(Passenger passenger)
            {
                bool isMilitary = passenger.IsMilitary;
                bool needsHelp = passenger.NeedsHelp;
                int group = passenger.BoardingGroup;

                return Status switch
                {
                    BoardingStatus.PlaneDeparted => "Flight Departed",
                    BoardingStatus.NotStarted => "Boarding Not Started",
                    BoardingStatus.Boarding when isMilitary || needsHelp => "Board Now via Priority Lane",
                    BoardingStatus.Boarding when CurrentBoardingGroup < group => "Please Wait",
                    BoardingStatus.Boarding when _priorityLaneGroups.Contains(group) => "Board Now via Priority Lane",
                    BoardingStatus.Boarding => "Board Now",
                    _ => throw new NotSupportedException($"Unsupported Status {Status}"),
                };
            }

            public Passenger(string firstName, string lastName)
            {
                FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
                LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            }

            public override string ToString() => FullName;

            public static class DateHelpers
            {
                public static string Format(this DateTime time)
                {
                    return time.ToString("ddd MMM dd HH:mm tt");
                }
            }

              private IFlightInfo? FindFlightById(string id) => _scheduler.GetAllFlights().FirstOrDefault(f => f.Id == id);

            */

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
            string message = GameConstants.ErrorWrongSelection;
            if (!_gameValidations.IsInRange(inputString, out index))
            {
                return (false, message);
            }
            //Out of range exception
            bool isNotVacant = _boardService.BoxesContains(index - 1);
            if (isNotVacant)
            {
                message = GameConstants.ErrorNotVacant;
                return (false, message);
            }
            return (true, string.Empty);
        }

        private void SwitchPlayer() => _currentPlayer = _currentPlayer == CurrentPlayer.Y || _currentPlayer == CurrentPlayer.N ? CurrentPlayer.X : CurrentPlayer.Y;

        private void UpdateBoard(int position) => _boardService.UpdateBox(position - 1, _currentPlayer.ToString().First());

        private void CheckWinner()
        {
            // 123, 456, 789, 147, 258, 369, 159, 357
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
                //validate input range before calling this method
                if (_boardService.BoxesContains(combination[0], currentPlayerChar) &&
                    _boardService.BoxesContains(combination[1], currentPlayerChar) &&
                    _boardService.BoxesContains(combination[2], currentPlayerChar))
                    {
                        _IsWinner = true;
                        _winPlayer = _currentPlayer;
                        break;
                    }
                    //if (_boardService.BoxesContains(combination, _currentPlayer.ToString().First()))
            }
        }

        public void EndGame()
        {
            Console.Clear();
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


/*


private void GetInput()
        {
            string? inputString = Console.ReadLine();

            if (!ValidateInput(inputString, out string message, out int index))
            {
                PrintMessage(message, true, false);
                Console.ReadKey();
                GetInput();
            }
            UpdateBoard(index);
        }

        private bool ValidateInput(string? inputString, out string message, out int index)
        {
            message = GameConstants.ErrorWrongSelection;
            if (!_gameValidations.IsInRange(inputString, out index))
            {
                return false;
            }

            bool isNotVacant = _boardService.BoxesContains(index - 1);
            if (isNotVacant)
            {
                message = GameConstants.ErrorNotVacant;
                return false;
            }
            return true;
        }


}*/
