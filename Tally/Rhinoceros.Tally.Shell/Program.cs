using Rhinoceros.Tally.Damain;
using System;

namespace Rhinoceros.Tally.Shell
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountBook.ReadAllLog();

            var isExit = false;
            do
            {
                Console.Clear();
                PrintSign();
                PrintMenu(ref isExit);

                if (!isExit)
                {
                    Console.WriteLine("\nPls, input any key to continue...(without Q/q)");
                    var input = Console.ReadKey();
                    if (input.Key == ConsoleKey.Q) { isExit = true; }
                }
            } while (!isExit);
        }

        static void PrintSign()
        {
            var cacheColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(@"      _____                    _____                    _____            _____        _____          ");
            Console.WriteLine(@"     /\    \                  /\    \                  /\    \          /\    \      |\    \         ");
            Console.WriteLine(@"    /::\    \                /::\    \                /::\____\        /::\____\     |:\____\        ");
            Console.WriteLine(@"    \:::\    \              /::::\    \              /:::/    /       /:::/    /     |::|   |        ");
            Console.WriteLine(@"     \:::\    \            /::::::\    \            /:::/    /       /:::/    /      |::|   |        ");
            Console.WriteLine(@"      \:::\    \          /:::/\:::\    \          /:::/    /       /:::/    /       |::|   |        ");
            Console.WriteLine(@"       \:::\    \        /:::/__\:::\    \        /:::/    /       /:::/    /        |::|   |        ");
            Console.WriteLine(@"       /::::\    \      /::::\   \:::\    \      /:::/    /       /:::/    /         |::|   |        ");
            Console.WriteLine(@"      /::::::\    \    /::::::\   \:::\    \    /:::/    /       /:::/    /          |::|___|______  ");
            Console.WriteLine(@"     /:::/\:::\    \  /:::/\:::\   \:::\    \  /:::/    /       /:::/    /           /::::::::\    \ ");
            Console.WriteLine(@"    /:::/  \:::\____\/:::/  \:::\   \:::\____\/:::/____/       /:::/____/           /::::::::::\____\");
            Console.WriteLine(@"   /:::/    \::/    /\::/    \:::\  /:::/    /\:::\    \       \:::\    \          /:::/~~~~/~~      ");
            Console.WriteLine(@"  /:::/    / \/____/  \/____/ \:::\/:::/    /  \:::\    \       \:::\    \        /:::/    /         ");
            Console.WriteLine(@" /:::/    /                    \::::::/    /    \:::\    \       \:::\    \      /:::/    /          ");
            Console.WriteLine(@"/:::/    /                      \::::/    /      \:::\    \       \:::\    \    /:::/    /           ");
            Console.WriteLine(@"\::/    /                       /:::/    /        \:::\    \       \:::\    \   \::/    /            ");
            Console.WriteLine(@" \/____/                       /:::/    /          \:::\    \       \:::\    \   \/____/             ");
            Console.WriteLine(@"                              /:::/    /            \:::\    \       \:::\    \                      ");
            Console.WriteLine(@"                             /:::/    /              \:::\____\       \:::\____\                     ");
            Console.WriteLine(@"                             \::/    /                \::/    /        \::/    / by Jonathan.lia     ");
            Console.WriteLine(@"                              \/____/                  \/____/          \/____/  forethic@outlook.com");

            Console.ForegroundColor = cacheColor;
        }

        static void PrintMenu(ref bool isExit)
        {
            Console.WriteLine("1.(a) Add a log.");
            Console.WriteLine("2.(s) Show all logs.");
            Console.WriteLine("3.(q) Exit.");

            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.A:
                    AddLog();
                    break;

                case ConsoleKey.S:
                    PrintAllLog();
                    break;

                case ConsoleKey.Q:
                    isExit = true;
                    break;
            }
        }

        static void AddLog()
        {
            Log.AddLog();
        }

        static void PrintAllLog()
        {
            AccountBook.DisplayAllLog();
        }
    }
}