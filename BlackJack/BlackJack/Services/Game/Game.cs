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
            shoes = ShoesServ.CreateShoes(decksQty);
        }

        public void StartGame()
        {
            Console.Clear();
            while(true)
            {     
                gameNumber++;

                PlayerServ.MakeABet(player);

                StartCircle();

                if (player.Money == 0)
                    break;

                ConsoleCommand.StartANewCircle();
            }
        }

        
        void StartCircle()
        {
            PlayerServ.AddCard(player, ShoesServ.GetNextCard(shoes));
            PlayerServ.AddCard(dealer, ShoesServ.GetNextCard(shoes));

            while (true)
            {
                ConsoleCommand.GameStats(player, dealer, shoes, gameNumber);

                if (ConsoleCommand.NextCard())
                {
                    PlayerServ.AddCard(player, ShoesServ.GetNextCard(shoes));
                    continue;
                }
                break;
            }

            PlayerServ.AddCard(dealer, ShoesServ.GetNextCard(shoes));
            ConsoleCommand.GameStats(player, dealer, shoes, gameNumber);

            WhosWin(player, dealer);

            PlayerServ.ClearCards(player);
            PlayerServ.ClearCards(dealer);
        }

        void WhosWin(Player player, Dealer dealer)
        {
            int playerPoints = PlayerServ.GetPoints(player), dealerPoints = PlayerServ.GetPoints(dealer);
            if (playerPoints > 21 || playerPoints < dealerPoints)
            {
                ConsoleCommand.PrintLose();
                return;
            }
            if (playerPoints >= dealerPoints)
            {
                ConsoleCommand.PrintWin();
                player.Money += player.CurrentBet * 2;
            }
        }
    }
}
