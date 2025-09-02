#nullable disable warnings
using System.ComponentModel;
using System.Reflection;
using TicTacToe.Domain;

namespace TicTacToe.Providers
{
    public abstract class BaseConsoleProvider : IConsoleProvider
    {
        public ConsoleInfo? GameConsoleInfo { get; set; }
        public IAppState AppState = new AppState(CurrentPlayerType.N, CurrentPlayerType.N, false,
            new List<char> { GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty },
            string.Empty);

        protected string messageUpdated = null;

        public BaseConsoleProvider()
        {
            //AppState.PropertyChanged += AppState_PropertyChanged;
        }

        public void SetErrorMessage(string errorMessage)
        {
            this.messageUpdated = errorMessage;
            AppState.ErrorMessage = errorMessage;
        }

        public abstract void HandleConsole();

        /*private void AppState_PropertyChanged(object sender, PropertyChangedEventArgs e)
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
