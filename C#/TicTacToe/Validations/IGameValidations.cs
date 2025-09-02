namespace TicTacToe.Validations 
{
    public interface IGameValidations
    {
        bool IsInRange(string? input, out int index);
        bool IsValidInputCharacter(string? input);
        bool IsCorrectInputLength(string? input);
        bool IsVacant(char inputChar, List<char> boxes);
    }
}
