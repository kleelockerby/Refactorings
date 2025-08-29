using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Services 
{
    public class BoardWriter : IBoardWriter
    {
        public void WriteBoard(List<char> boxes)
        {
            Console.WriteLine(" {0} | {1} | {2} ", boxes[0], boxes[1], boxes[2]);
            Console.WriteLine(" --------- ");
            Console.WriteLine(" {0} | {1} | {2} ", boxes[3], boxes[4], boxes[5]);
            Console.WriteLine(" --------- ");
            Console.WriteLine(" {0} | {1} | {2} ", boxes[6], boxes[7], boxes[8]);
        }

        public void GameWriter(string message)
        {
            Console.WriteLine(message);
        }
    }
}
