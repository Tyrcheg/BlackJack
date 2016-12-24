using System;


namespace BlackJack
{
    static class ConsoleCommand
    {
        public static string PlayersNameEnter()
        {
            Console.Write("Enter your name: ");
            string s = Console.ReadLine();
            if (s != "")
                return s;
            return "No name";
        }

        public static bool StartANewGame()
        {
            Console.Write("Do you want to start a new game y/n?");
            var answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "y" || answer == "н")
                return true;

            return false;
        }

        public static int DepositEnter()
        {
            while (true)
            {
                int x;
                Console.Write("Enter your deposit: ");

                if (int.TryParse(Console.ReadLine(), out x) && x > 0)
                    return x;

                Console.WriteLine(new string('-', 20) + "\nError. Try again.");
            }
        }

        public static void GameEnd()
        {
            Console.Clear();
            Console.WriteLine("Thanx for game! Goodluck!");
        }

        public static void NoMoneyMessage()
        {
            Console.WriteLine(new string('!', 28) + "\nYou have lost all your money\n" + new string('!', 28) + "\n");
        }

        public static int DecksQtyEnter()
        {
            while(true)
            {
                ushort decksQty;
                if (ushort.TryParse(Console.ReadLine(), out decksQty) && decksQty > 1 && decksQty < 5)
                    return decksQty;

                Console.WriteLine("--" + "\nError\nEnter a quantity from 1 to 4");
            }
        }

    }
}
