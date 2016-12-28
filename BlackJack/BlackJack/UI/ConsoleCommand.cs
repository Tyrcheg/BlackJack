using BlackJack.Services;
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
                return s.Replace(s[0], char.ToUpper(s[0]));

            return "No name";
        }

        public static bool StartANewGame()
        {
            Console.Write("Do you want to start a new game y/n? ");
            var answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "y" || answer == "н")
                return true;

            return false;
        }

        internal static int BetEnter(int money)
        {
            while (true)
            {
                Console.Write("Place your bet. ({0}$ available) : ", money);
                int newBet;

                if (!int.TryParse(Console.ReadLine(), out newBet))
                {
                    Console.WriteLine("\n" + new string('-', 20) + "\nError:\nEnter number value");
                    continue;
                }

                if (newBet < 1)
                {
                    Console.WriteLine(new string('-', 20) + "\nError:\nU can't set negative or zero bet!");
                    Console.Write("Try to enter your bet againg: ");
                    continue;
                }

                if (money - newBet < 0)
                {
                    Console.WriteLine(new string('-', 20) + "\nError:\nU dont have much money");
                    Console.Write("Try to enter your bet again: ");
                    continue;
                }
                return newBet;
            }
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

        public static void GameStats(Player player, Dealer dealer, Shoes shoes, int gameNumber)
        {
            Console.Clear();
            Console.WriteLine("Players' name: {0}", player.Name);
            Console.WriteLine(new string('-', 15 + player.Name.Length));
            Console.WriteLine("Your cash: {0}$", player.Money);
            Console.WriteLine(new string('-', 17) + "\nGame #{0}", gameNumber);
            Console.WriteLine("Current bet: {0}$", player.CurrentBet);
            Console.WriteLine("Cards in shoes: {0}", ShoesServ.CountCardsInShoes(shoes));

            Console.WriteLine("Dealers' cards: ");
            PrintCurrentCards(dealer);
            Console.WriteLine("Players' cards:");
            PrintCurrentCards(player);

            Console.WriteLine(new string('-', 17));
        }

        public static void GameEnd()
        {
            Console.Clear();
            Console.WriteLine("Thanx for game! Goodluck!\n");
        }

        public static void NoMoneyMessage()
        {
            Console.WriteLine("\nYou've lost all your money\n");
        }

        public static int DecksQtyEnter()
        {
            while (true)
            {
                ushort decksQty;
                if (ushort.TryParse(Console.ReadLine(), out decksQty) && decksQty > 1 && decksQty < 5)
                    return decksQty;

                Console.WriteLine("--" + "\nError\nEnter a quantity from 1 to 8");
            }
        }

        public static bool NextCard()
        {
            Console.CursorVisible = false;
            Console.Write("Press 'space' to get one more card or any key to end the circle.");
            if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                return true;

            Console.CursorVisible = true;
            return false;
        }

        public static void StartANewCircle()
        {
            Console.CursorVisible = false;

            Console.WriteLine("\nPress enter no start a new circle.");
            Console.ReadLine();

            Console.CursorVisible = true;
        }

        public static void PrintCurrentCards(BasePlayersClass player)
        {
            foreach (Card card in player.Cards)
                Console.Write(CardServ.GetFullCardName(card) + " ");
            Console.WriteLine();
        }

        public static void PrintWin()
        { Console.WriteLine("You win"); }

        public static void PrintLose()
        { Console.WriteLine("You lose"); }


    }
}
