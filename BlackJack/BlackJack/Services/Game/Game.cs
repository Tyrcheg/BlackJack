using System;
using BlackJack.Services;

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
            shoes = ShoesServices.CreateShoes(decksQty);
        }

        public void StartGame()
        {
            Console.Clear();
            while(true)
            {     
                gameNumber++;

                PlayerServices.MakeABet(player);

                StartCircle();

                if (player.Money == 0)
                {
                    break;
                }

                ConsoleCommand.StartANewCircle();
            }

        }

        
        void StartCircle()
        {
            PlayerServices.AddCard(player, ShoesServices.GetNextCard(shoes));
            PlayerServices.AddCard(dealer, ShoesServices.GetNextCard(shoes));

            while (true)
            {
                PrintGameStats();

                if (ConsoleCommand.NextCard())
                {
                    PlayerServices.AddCard(player, ShoesServices.GetNextCard(shoes));
                    continue;
                }
                break;
            }
            PlayerServices.AddCard(dealer, ShoesServices.GetNextCard(shoes));
            PrintGameStats();

            WhosWin(player, dealer);

            PlayerServices.ClearCards(player);
            PlayerServices.ClearCards(dealer);
        }

        void WhosWin(Player player, Dealer dealer)
        {
            int pp = PlayerServices.GetPoints(player), dp = PlayerServices.GetPoints(dealer);
            if (pp > 21 || pp < dp)
            {
                ConsoleCommand.PrintLose();
                return;
            }
            if (pp > dp)
            {
                ConsoleCommand.PrintWin();
                player.Money += player.CurrentBet * 2;
            }
        }

        void PrintGameStats()
        {
            Console.Clear();
            Console.WriteLine("Players' name: {0}", player.Name);
            Console.WriteLine(new string('-', 20) + "\nYour cash: {0}$", player.Money);
            Console.WriteLine(new string('-', 20) + "\nGame #{0}", gameNumber);
            Console.WriteLine("Current bet: {0}$", player.CurrentBet);
            Console.WriteLine("Cards in deck: {0}", ShoesServices.CountCardsInShoes(shoes));

            Console.WriteLine("Dealers' cards: " );
            ConsoleCommand.PrintCurrentCards(dealer);
            Console.WriteLine("Players' cards:");
            ConsoleCommand.PrintCurrentCards(player);

            Console.WriteLine(new string('-', 20));
        }
    }
}
