using System.Text;

namespace TicTacToe.Models
{
    public class BoxModel
    {
        public List<char> Boxes { get; set; }

        public BoxModel()
        {
            Boxes = new List<char> { GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty, GameConstants.BoxEmpty };
        }

        public void UpdateBox(int index, char currentPlayerChar)
        {
            if (index < GameConstants.MinMoveCount || index >= Boxes.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be between 0 and 8.");
            }
            if (Boxes[index] != ' ')
            {
                throw new InvalidOperationException("Box is already occupied.");
            }
            Boxes[index] = currentPlayerChar;
        }

        public bool IsEmpty(int index)
        {
            if(Boxes[index] != GameConstants.BoxEmpty)
            {
                return false;
            }
            return true;
        }

        public bool BoxesContains(List<int> boxNos, char player)
        {
            bool result = true;
            boxNos.ForEach(x =>
            {
                if (Boxes[x] != player)
                {
                    result = false;
                }
            });
            return result;
        }

        public string CreateMessage()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(GameConstants.BoardRow + GameConstants.NewLine + GameConstants.BoardSeparator, this.Boxes[0], this.Boxes[1], this.Boxes[2]));
            sb.AppendLine(string.Format(GameConstants.BoardRow + GameConstants.NewLine + GameConstants.BoardSeparator, this.Boxes[3], this.Boxes[4], this.Boxes[5]));
            sb.AppendLine(string.Format(GameConstants.BoardRow + GameConstants.NewLine + GameConstants.BoardSeparator, this.Boxes[6], this.Boxes[7], this.Boxes[8]));
            return sb.ToString();
        }
    }
}
