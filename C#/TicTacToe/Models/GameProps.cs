using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class GameProps
    {
        public int MoveCount { get;  }
        public char AskMove { get;  }
        public int SelTemp { get;  }
        public bool Error { get;  }
        public bool IsY { get;  }

        public GameProps(int moveCount, char askMove, int selTemp, bool error, bool isY)
        {
            MoveCount = moveCount;
            AskMove = askMove;
            SelTemp = selTemp;
            Error = error;
            IsY = isY;
        }
    }
}
