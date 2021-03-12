using System;
using System.Collections.Generic;

namespace Rhinoceros.Tally.Damain
{
    public class AccountBook
    {
        public static List<Log> Logs = new List<Log>();

        public static void DisplayAllLog()
        {
            Console.WriteLine("\nDisplay all logs---------------------");
            var cacheColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var log in Logs)
            {
                Console.WriteLine(log);
            }
            Console.ForegroundColor = cacheColor;
        }
    }
}