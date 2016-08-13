using BackGammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard game = new GameBoard();

            Console.WriteLine(game.ToString());

            Console.ReadLine();
        }
    }
}
