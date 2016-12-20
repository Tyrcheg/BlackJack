using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    static class ConsoleCommand
    {
        public static string PlayersNameEnter()
        {
            Console.Write("Enter your name: ");
            return Console.ReadLine();       
        }

        public static bool StartANewGame()
        {
            Console.WriteLine("Do you want to start a new game y/n?");
            var answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "y" || answer == "н")
                return true;

            return false;
        }

        public int DepositEnter()
        {
            Console.Write("Enter your deposit: ");
            int x = 0;
            if (int.TryParse(Console.ReadLine(), out x))
                return x;
            return 0;
        }

    }
}
