namespace TicTacToe.Services 
{
    public interface IGameValidations
    {
        bool IsInRange(string? input, out int index);
        bool IsCorrectInputLength(string? input);
        bool IsVacant(int index, BoxModel boxes);
    }
}
