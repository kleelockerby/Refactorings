namespace TicTacToe.Validations
{
    public class GameValidations : IGameValidations
    {
        public bool IsInRange(string? input, out int boxCellNo)
        {
            bool isInputInt = input.IsValidInteger(out boxCellNo);
            if (boxCellNo > GameConstants.MaxMoveCount || boxCellNo <= GameConstants.MinMoveCount)
            {
                throw new ArgumentOutOfRangeException(nameof(boxCellNo), "Index must be between 0 and 8.");
            }
            return true;
        }

        public bool IsValidInputCharacter(string? input)
        {
            return IsInRange(input, out _);
        }

        public bool IsCorrectInputLength(string? input) => input?.Length > GameConstants.MaxInputLength ? false : true;

        public bool IsVacant(char inputChar, List<char> boxes) => boxes.Contains(inputChar) ? false : true;
    }
}