using System;
using System.Threading;
using TicTacToe.Models;

namespace CSharpRefactorings.TicTacToe.Original
{
    public class Program
    {
        
        static void Main()
        {
            Game game = new Game();
            game.SetProperties(new GameProps(moveCount: 0, askMove: default, selTemp: default, error: false, isY: true));

            List<char> boxes = new List<char> { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            game.SetBoxes(boxes);

            //Fix SRP violation by moving all game logic to Game class
            Console.WriteLine(" -- Tic Tac Toe -- ");
            Thread.Sleep(1200);
            Console.Clear();
          
            while (!prog.isWin)
            {
                if (moveCount == 9)
                {
                    prog.DisplayLoss();
                }
                if ((prog.isY) == true) // if is X
                {
                    askMove = 'X';
                }
                else
                {
                    askMove = 'Y';
                }
                Console.Clear();
                prog.WriteBoard();
                Console.WriteLine();
                Console.WriteLine("What box do you want to place {0} in? (1-9)", askMove);
                Console.Write("> ");
                selTemp = int.Parse(Console.ReadLine());
                switch (selTemp)
                {
                    case 1:
                        if (prog.box1 == ' ')
                        {
                            prog.box1 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }
                        break;
                    case 2:
                        if (prog.box2 == ' ')
                        {
                            prog.box2 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }
                        break;
                    case 3:
                        if (prog.box3 == ' ')
                        {
                            prog.box3 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }
                        break;
                    case 4:
                        if (prog.box4 == ' ')
                        {
                            prog.box4 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }
                        break;
                    case 5:
                        if (prog.box5 == ' ')
                        {
                            prog.box5 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }
                        break;
                    case 6:
                        if (prog.box6 == ' ')
                        {
                            prog.box6 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }
                        break;
                    case 7:
                        if (prog.box7 == ' ')
                        {
                            prog.box7 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }
                        break;
                    case 8:
                        if (prog.box8 == ' ')
                        {
                            prog.box8 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }
                        break;
                    case 9:
                        if (prog.box9 == ' ')
                        {
                            prog.box9 = askMove;
                            moveCount++;
                        }
                        else
                        {
                            prog.NotVacantError();
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong selection entered!");
                        Console.WriteLine("Press any key to try again..");
                        Console.ReadKey();
                        prog._error = true;
                        break;
                }
                if (prog._error)
                {
                    prog.CheckWin(); // if error, just check win
                    prog._error = !prog._error;
                }
                else
                {
                    prog.isY = !prog.isY; // flip boolean
                    prog.CheckWin();
                }
            }
            Console.Clear();
            prog.WriteBoard();
            Console.WriteLine();
            Console.WriteLine("The winner is {0}!", prog.winPerson);
            Console.ReadKey();
        }
    }
}
