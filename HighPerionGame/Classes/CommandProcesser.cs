using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighPerionGame
{
    static class CommandProcesser
    {
        public static void ProcessCommand(string line)
        {
            string command = TextUtilils.ExtractCommand(line.Trim()).Trim().ToLower();
            string arguments = TextUtilils.ExtractArgueMent(line.Trim()).ToLower();

            switch (command)
            {
                case "exit":
                    Program.Quit = true;
                    return;
                case "help":
                    ShowHelp();
                    break;
                case "move":
                    Player.Move(arguments);
                    break;
                case "look":
                    Player.GetCurrentRoom().Describe();
                    break;
                case "pickup":
                    Player.PickUpItem(arguments);
                    break;
                case "drop":
                    Player.DropItem(arguments);
                    break;
                case "inventory":
                    Player.DisplayInventory();
                    break;
                case "whereami":
                    Player.GetCurrentRoom().ShowTitle();
                    break;
                default:
                    TextBuffer.Add("Not a Valid Command");
                    break;
            }
            GameManager.ApplyRules();
            TextBuffer.Display();

        }

        public static void ShowHelp()
        {
            TextBuffer.Add("Available Commands:");
            TextBuffer.Add("-------------------");
            TextBuffer.Add("help");
            TextBuffer.Add("move [north,south,west,east]");
            TextBuffer.Add("look");
            TextBuffer.Add("drop");
            TextBuffer.Add("pickup");
            TextBuffer.Add("inventory");
            TextBuffer.Add("whereami");
        }
    }
}
