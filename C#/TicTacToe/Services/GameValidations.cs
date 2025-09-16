using TicTacToe.Extensions;

namespace TicTacToe.Services
{
    public class GameValidations : IGameValidations
    {
        public bool IsInRange(string? input, out int boxCellNo)
        {
            bool isInputInt = input.IsValidInteger(out boxCellNo);
            int index = boxCellNo > 0 ? boxCellNo - 1 : boxCellNo;
            if(boxCellNo < 0)
            {
                return false;
            }
            if (boxCellNo > GameConstants.MaxMoveCount || boxCellNo <= GameConstants.MinMoveCount)
            {
                return false;
            }
            return true;
        }

        public bool IsCorrectInputLength(string? input) => input?.Length > GameConstants.MaxInputLength ? false : true;

        public bool IsVacant(int index, BoxModel boxes)
        {
            bool isVacant = false;
            if (boxes.IsEmpty(index))
            {
                isVacant = true;
            }
            return isVacant;
        }
    }
}