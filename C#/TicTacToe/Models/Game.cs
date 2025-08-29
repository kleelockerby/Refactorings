using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Services;

namespace TicTacToe.Models
{
    public class Game
    {
        private readonly IBoardWriter _boardWriter;

        private char winChar;
        private char boxone, boxtwo, boxthree, boxfour, boxfive, boxsix, boxseven, boxeight, boxnine;
        private bool hasWon;

        private List<char> boxes;

        public char winPerson
        {
            get { return winChar; }
            set { winChar = value; }
        }

        public bool isWin
        {
            get { return hasWon; }
            set { hasWon = value; }
        }

        private bool _hasError;
        public bool Error
        {
            get { return _hasError; }
            set { _hasError = value; }
        }

        private bool _isX;
        public bool IsX
        {
            get { return _isX; }
            set { _isX = value; }
        }
        private bool _isY;
        public bool isY
        {
            get { return _isX; }
            set { _isX = value; }
        }

        private GameProps _gameProps;

        private int _moveCount;
        private char _askMove;
        private int _selTemp;

        public Game() : this(new BoardWriter()){}
        public Game(IBoardWriter boardWriter)
        {
            this._boardWriter = boardWriter;
        }

        public void SetProperties(GameProps gameProps)
        {
            this._moveCount = gameProps.MoveCount;
            this._askMove = gameProps.AskMove;
            this._selTemp = gameProps.SelTemp;
            this._hasError = gameProps.Error;
            this._isY = gameProps.IsY;
        }

        public void SetBoxes(List<char> boxes)
        {
            this.boxes = boxes;
        }

        public void WriteBoard()
        {
            Console.WriteLine(" {0} | {1} | {2} ", boxone, boxtwo, boxthree);
            Console.WriteLine(" --------- ");
            Console.WriteLine(" {0} | {1} | {2} ", boxfour, boxfive, boxsix);
            Console.WriteLine(" --------- ");
            Console.WriteLine(" {0} | {1} | {2} ", boxseven, boxeight, boxnine);
        }

        public void CheckWin()
        {
            // 123, 456, 789, 147, 258, 369, 159, 357
            if ((box1 == 'X') && (box2 == 'X') && (box3 == 'X'))
            {
                isWin = true;
                winPerson = 'X';
                return;
            }
            if ((box4 == 'X') && (box5 == 'X') && (box6 == 'X'))
            {
                isWin = true;
                winPerson = 'X';
                return;
            }
            if ((box7 == 'X') && (box8 == 'X') && (box9 == 'X'))
            {
                isWin = true;
                winPerson = 'X';
                return;
            }
            if ((box1 == 'X') && (box4 == 'X') && (box7 == 'X'))
            {
                isWin = true;
                winPerson = 'X';
                return;
            }
            if ((box2 == 'X') && (box5 == 'X') && (box8 == 'X'))
            {
                isWin = true;
                winPerson = 'X';
                return;
            }
            if ((box3 == 'X') && (box6 == 'X') && (box9 == 'X'))
            {
                isWin = true;
                winPerson = 'X';
                return;
            } // 159, 357
            if ((box1 == 'X') && (box5 == 'X') && (box9 == 'X'))
            {
                isWin = true;
                winPerson = 'X';
                return;
            }
            if ((box3 == 'X') && (box5 == 'X') && (box7 == 'X'))
            {
                isWin = true;
                winPerson = 'X';
                return;
            }
            if ((box1 == 'Y') && (box2 == 'Y') && (box3 == 'Y'))
            {
                isWin = true;
                winPerson = 'Y';
                return;
            }
            if ((box4 == 'Y') && (box5 == 'Y') && (box6 == 'Y'))
            {
                isWin = true;
                winPerson = 'Y';
                return;
            }
            if ((box7 == 'Y') && (box8 == 'Y') && (box9 == 'Y'))
            {
                isWin = true;
                winPerson = 'Y';
                return;
            }
            if ((box1 == 'Y') && (box4 == 'Y') && (box7 == 'Y'))
            {
                isWin = true;
                winPerson = 'Y';
                return;
            }
            if ((box2 == 'Y') && (box5 == 'Y') && (box8 == 'Y'))
            {
                isWin = true;
                winPerson = 'Y';
                return;
            }
            if ((box3 == 'Y') && (box6 == 'Y') && (box9 == 'Y'))
            {
                isWin = true;
                winPerson = 'Y';
                return;
            } // 159, 357
            if ((box1 == 'Y') && (box5 == 'Y') && (box9 == 'Y'))
            {
                isWin = true;
                winPerson = 'Y';
                return;
            }
            if ((box3 == 'Y') && (box5 == 'Y') && (box7 == 'Y'))
            {
                isWin = true;
                winPerson = 'Y';
                return;
            }
        }

        public void NotVacantError()
        {
            this.Error = true;
            Console.WriteLine();
            Console.WriteLine("Error: box not vacant!");
            Console.WriteLine("Press any key to try again..");
            Console.ReadKey();
            return;
        }

        public void DisplayLoss()
        {
            Console.WriteLine();
            Console.WriteLine("No one won.");
            Console.ReadKey();
            Environment.Exit(1);
        }

        
    }
}
