using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighPerionGame
{
    static class GameManager
    {
        //Public Methods
        public static void ShowTitleScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(TextUtilils.WordWrap("***   Welcome to HighPerion! ***"+ "\n\n\n", Console.WindowWidth));
            //Console.WriteLine(TextUtilils.WordWrap("***   Welcome to HighPerion!   ***"+ "\n\n\n",Console.WindowWidth));

            Console.WriteLine("\nNote: You can type 'help' at any time to see a list of commands");
            Console.WriteLine("\nPress a key to begin...");
            Console.CursorVisible = false;
            Console.ReadKey();
            Console.CursorVisible = true;
            Console.Clear();
        }


        public static void StartGame()
        {
            Player.GetCurrentRoom().Describe();
            TextBuffer.Display();
        }

        public static void EndGame(string endingText)
        {
            Program.Quit = true;
            Console.Clear();
            Console.WriteLine (TextUtilils.WordWrap(endingText, Console.WindowWidth));
            Console.WriteLine("\nYou Can Now close This Window...");
            Console.CursorVisible = false;

            while (true)
            {
                Console.ReadKey(true);
            }
        }

        public static void ApplyRules()
        {
            if (Level.Rooms[0, 0].GetItem("Red Ball") != null && 
                Level.Rooms[1, 0].GetItem("Blue Ball") != null && 
                Level.Rooms[1, 1].GetItem("Yellow Ball") != null && 
                Level.Rooms[0, 1].GetItem("Green Ball") != null)
            {
                EndGame("Perfect! LEVEL COMPLETED!");
            }
            if (Player.GetInventoryItem("golden key") != null)
            {
                Level.Rooms[0, 0].Description = "You Have Entered The Red room.";
                Level.Rooms[0, 1].Description = "You Have Entered The Green room.";
                Level.Rooms[0, 0].AddExit(Direction.South); //red
                Level.Rooms[0, 1].AddExit(Direction.North); // green
            }
            if (Player.Moves > 10)
            {
                EndGame("Waaaaay to slow! GAME OVER");
            }

        }

    }
}
