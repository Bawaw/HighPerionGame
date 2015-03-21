using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighPerionGame
{
    class Program
    {
        public static bool Quit = false;

        static void Main(string[] args)
        {
            GameManager.ShowTitleScreen();
            Level.Initialize();
            GameManager.StartGame();

            while (!Quit)
            { 
                CommandProcesser.ProcessCommand(Console.ReadLine());
            }
        }
    }
}
