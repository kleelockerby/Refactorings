using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TicTacToe.State
{
    public interface IAppState
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        CurrentPlayerType? CurrentPlayer { get; set; }
        CurrentPlayerType? WinPlayer { get; set; }
        bool? IsWinner { get; set; }
        string? ErrorMessage { get; set; }
        void UpdateBoxes(int index);
        public void OnPropertyChanged([CallerMemberName] string propertyName = null!);
    }
}
