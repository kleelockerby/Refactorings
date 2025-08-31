namespace TicTacToe.Validations 
{
    public interface IGameValidations
    {
        bool IsInRange(string? input, out int index);
        bool IsNotVacant(char inputChar, List<char> boxes);
    }
}
