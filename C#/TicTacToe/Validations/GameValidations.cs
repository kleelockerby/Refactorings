namespace TicTacToe.Validations
{
    public class GameValidations : IGameValidations
    {
        public bool IsInRange(string? input, out int index)
        {
            bool isInputInt = input.IsValidInteger(out index);
            if (index > GameConstants.MaxMoveCount || index <= GameConstants.MinMoveCount)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be between 0 and 8.");
            }
            return true;
        }

        public bool isCorrectInputLength(string? input) => input?.Length > GameConstants.MaxInputLength ? false : true;

        public bool IsVacant(char inputChar, List<char> boxes) => boxes.Contains(inputChar) ? false : true;
    }
}