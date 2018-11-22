using System;

namespace Common
{
    public static class ConsoleHelper
    {
        public static void WriteLine(string msg, ConsoleColor colour = ConsoleColor.White)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = colour;
            msg = DateTime.UtcNow.ToString("G") + " : " + msg;
            Console.WriteLine(msg);
            Console.ForegroundColor = originalColor;
        }
    }
}
