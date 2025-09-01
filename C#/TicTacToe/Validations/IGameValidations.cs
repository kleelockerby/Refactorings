namespace TicTacToe.Validations 
{
    public interface IGameValidations
    {
        bool IsInRange(string? input, out int index);
        bool isCorrectInputLength(string? input);
        bool IsVacant(char inputChar, List<char> boxes);
    }
}
