using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    //GameLogic
    class Game
    {
        int gameNumber = 0;
        Shoes shoes;
        Dealer dealer = Dealer.GetDealer;
        Player player;

        public Game(short decksQty, Player _player)
        {
            player = _player;
            shoes = new Shoes(decksQty);
        }

        Card GetNextCard { get { return shoes.GetNextCard(); } }

        public void StartGame()
        {
            Console.Clear();
            do
            {     
                gameNumber++;

                player.MakeABet();

                StartCircle();

                ConsoleCommand.StartANewCircle();
            }
            while (player.Money > 0);

            ConsoleCommand.NoMoneyMessage();
        }

        
        void StartCircle()
        {
            player.AddCard(GetNextCard);
            dealer.AddCard(GetNextCard);

            while (true)
            {
                PrintGameStats();

                if(ConsoleCommand.NextCard())
                    player.AddCard(GetNextCard);
                else
                    break;
            }
            dealer.AddCard(GetNextCard);
            PrintGameStats();

            int pp = player.GetPoints(), dp = dealer.GetPoints();
            if (pp > 21)
                Console.WriteLine("You lose");
            else if (pp > dp)
            {
                Console.WriteLine("You win");
                player.Money += player.CurrentBet * 2;
            }
            else
                Console.WriteLine("Your lose");
            Console.WriteLine();

            player.ClearCards();
            dealer.ClearCards();
        }



        void PrintGameStats()
        {
            Console.Clear();
            Console.WriteLine("Players' name: {0}", player.Name);
            Console.WriteLine(new string('-', 20) + "\nYour cash: {0}$", player.Money);
            Console.WriteLine(new string('-', 20) + "\nGame #{0}", gameNumber);
            Console.WriteLine("Current bet: {0}$", player.CurrentBet);
            Console.WriteLine("Cards in deck: {0}", shoes.Count);

            Console.WriteLine("Dealers' cards: " );
            dealer.PrintCurrentCards();
            Console.WriteLine("Players' cards:");
            player.PrintCurrentCards();

            Console.WriteLine(new string('-', 20));
        }
    }
}
