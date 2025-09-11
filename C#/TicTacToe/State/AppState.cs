using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TicTacToe.State
{
    public class AppState : IAppState, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private CurrentPlayerType? _currentPlayer;
        public CurrentPlayerType? CurrentPlayer
        {
            get => _currentPlayer;
            set
            {
                if (_currentPlayer != value)
                {
                    _currentPlayer = value;
                    OnPropertyChanged(nameof(CurrentPlayer));
                }
            }
        }

        private CurrentPlayerType? _winPlayer;
        public CurrentPlayerType? WinPlayer
        {
            get => _winPlayer;
            set
            {
                if (_winPlayer != value)
                {
                    _winPlayer = value;
                    OnPropertyChanged(nameof(WinPlayer));
                }
            }
        }

        private bool? _isWinner;
        public bool? IsWinner
        {
            get => _isWinner;
            set
            {
                if (_isWinner != value)
                {
                    _isWinner = value;
                    OnPropertyChanged(nameof(IsWinner));
                }
            }
        }

       /* private List<char>? _boxCells;
        public List<char>? BoxCells
        {
            get => _boxCells;
            set
            {
                if (_boxCells != value)
                {
                    _boxCells = value;
                    OnPropertyChanged(nameof(BoxCells));
                }
            }
        }*/

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }

        public AppState(CurrentPlayerType? currentPlayer, CurrentPlayerType? winPlayer, bool? isWinner, string? errorMessage)
        {
            _currentPlayer = currentPlayer;
            _winPlayer = winPlayer;
            _isWinner = isWinner;
            _boxCells = boxes;
            _errorMessage = errorMessage;

        }

        public void UpdateBoxes(int index)
        {
            if (index < GameConstants.MinMoveCount || index >= BoxCells.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be between 0 and 8.");
            }
            if (BoxCells[index] != ' ')
            {
                throw new InvalidOperationException("Box is already occupied.");
            }
            BoxCells[index] = CurrentPlayer.ToString().First();
            OnPropertyChanged(nameof(BoxCells));
        }


        public void OnPropertyChanged([CallerMemberName] string propertyName = null!) =>  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
