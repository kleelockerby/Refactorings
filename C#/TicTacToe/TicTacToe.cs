using TicTacToe.Domain;
using TicTacToe.State;

namespace CSharpRefactorings.TicTacToe
{
    public class Program
    {     
        static void Main()
        {
            GameManager gameManager = new GameManager();
            gameManager.PlayGame();
        }
    }
}
