namespace TicTacToe.Services
{
    public class BoardService : IBoardService
    {
        public List<char> Boxes { get; }

        public BoardService(List<char> boxes)
        {
            Boxes = boxes;
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

        public bool BoxesContains(int boxNo) => Boxes[boxNo] == ' ' ? false : true;

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

        public void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine(GameConstants.BoardRow + GameConstants.NewLine + GameConstants.BoardSeparator, Boxes[0], Boxes[1], Boxes[2]);
            Console.WriteLine(GameConstants.BoardRow + GameConstants.NewLine + GameConstants.BoardSeparator, Boxes[3], Boxes[4], Boxes[5]);
            Console.WriteLine(GameConstants.BoardRow + GameConstants.NewLine + GameConstants.BoardSeparator + GameConstants.NewLine, Boxes[6], Boxes[7], Boxes[8]);
        }
    }
}


