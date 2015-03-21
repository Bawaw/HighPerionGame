using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighPerionGame
{
    static class TextUtilils
    {
        public static string ExtractCommand(string Line)
        {
            int index = Line.IndexOf(' ');
            if (index == -1)
                return Line;
            else
                return Line.Substring(0, index);
        }

        public static string ExtractArgueMent(string line)
        {
            int index = line.IndexOf(' ');
            if (index == -1) // nothing found
                return "";
            else 
                return line.Substring(index + 1, line.Length - index - 1);
        }

        public static string WordWrap(string text, int bufferWith)
        {
            string result = "";
            string[] lines = text.Split('\n');

            foreach (string line in lines)
            {
                int lineLength = 0;
                string[] words = line.Split(' ');

                foreach (string word in words)
                {
                    if (word.Length + lineLength >= bufferWith - 1)
                    {
                        result += "\n";
                        lineLength = 0;
                    }
                    result += word + " ";
                    lineLength += word.Length + 1;
                }
                result += "\n";
            }
            return result;
        }
    }
}
