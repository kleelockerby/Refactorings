#nullable disable warnings
using System.ComponentModel;

namespace TicTacToe.Domain
{
    public class GameManager
    {
        public IAppState AppState = new AppState(CurrentPlayerType.N, CurrentPlayerType.N, false,
            new List<char> { GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty },
            string.Empty);

        //private CurrentPlayerType? lastCurrentPlayer;
        //private CurrentPlayerType? lastWinPlayer;
        //private bool? lastIsWinner;
        //private List<char> lastBoxCellNos;
        //private string lastErrorMessage;

        private GameProcessor gameProcessor;
        private int currentMoveCount = 0;

        public GameManager()
        {
            //AppState.PropertyChanged += _appState_PropertyChanged;
            gameProcessor = new GameProcessor();
        }

        public void PlayGame()
        {
            ConsoleHandler startHandler = ConsoleProviderCommands.GetProvider(ConsoleType.Start, out IConsoleProvider startProvider);
            ConsoleHandler boardHandler = ConsoleProviderCommands.GetProvider(ConsoleType.Board, out IConsoleProvider boardProvider);
            ConsoleHandler inputHandler = ConsoleProviderCommands.GetProvider(ConsoleType.Input, out IConsoleProvider inputProvider);
            ConsoleHandler errorHandler = ConsoleProviderCommands.GetProvider(ConsoleType.Board, out IConsoleProvider errorProvider);
            ConsoleHandler endHandler = ConsoleProviderCommands.GetProvider(ConsoleType.End, out IConsoleProvider endProvider);

            gameProcessor.StartGame(startHandler);

            while (currentMoveCount < GameConstants.MaxMoveCount)
            {
                gameProcessor.DrawBoard(boardHandler, inputHandler);
                gameProcessor.GetInput(errorHandler, errorProvider);
                gameProcessor.CheckWinner();
                if ((bool)AppState.IsWinner)
                {
                    break;
                }
                currentMoveCount++;
                gameProcessor.SwitchPlayer();
            }
            gameProcessor.EndGame(boardHandler, endHandler, endProvider);
        }




       /* private void _appState_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(IAppState.CurrentPlayer):
                    this.lastCurrentPlayer = AppState.CurrentPlayer;
                    break;
                case nameof(AppState.WinPlayer):
                    this.lastWinPlayer = AppState.WinPlayer;
                    break;
                case nameof(AppState.IsWinner):
                    this.lastIsWinner = AppState.IsWinner;
                    break;
                case nameof(AppState.BoxCells):
                    this.lastBoxCellNos = AppState.BoxCells;
                    break;
                case nameof(AppState.ErrorMessage):
                    this.lastErrorMessage = AppState.ErrorMessage;
                    break;
            }
        }*/
    }
}
