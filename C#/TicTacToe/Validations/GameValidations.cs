
namespace TicTacToe.Validations
{
    public class GameValidations : IGameValidations
    {
        public bool IsInRange(string? input, out int index)
        {
            if (string.IsNullOrEmpty(input))
            {
                index = -1;
                return false;
            }
            bool isInputInt = IsValidInt(input, out index);
            if (!isInputInt)
            {
                return false;
            }
            bool isValid = index <= GameConstants.MaxMoveCount && index > GameConstants.MinMoveCount;
            index = isValid ? index : -1;
            return isValid;
        }

        public bool IsNotVacant(char inputChar, List<char> boxes)
        {
            return boxes.Contains(inputChar) ? false : true;
        }

        private bool IsValidInt(string? input, out int inputInt)
        {
            if(int.TryParse(input, out inputInt))
            {
                return true;
            }
            inputInt = -1;
            return false;
        }
    }
}