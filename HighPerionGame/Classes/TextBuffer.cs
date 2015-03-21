using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighPerionGame
{
    static class TextBuffer
    {
       private static string outputBuffer;


       public static void Add(string text)
       {
           outputBuffer += text + "\n";
       }

       public static void Display()
       {
           Console.Clear();
           Console.Write(TextUtilils.WordWrap (outputBuffer, Console.WindowWidth)); //no new line
           Console.WriteLine("What shall I do?"); //newline
           Console.Write(">");

           outputBuffer = "";
       }
    }
}
