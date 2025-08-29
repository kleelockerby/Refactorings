using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Services 
{
    public interface IBoardWriter
    {
        void WriteBoard(List<char> boxes);
        void GameWriter(string message);
    }
}
