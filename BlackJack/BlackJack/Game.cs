using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Game
    {
        int money, bet, gameNomber = 0;
        Shoes shoes; Player player;

        // ctors
        public Game(int _money, short decksQty, Player _player)
        {
            money = _money;
            player = _player;
            shoes = new Shoes(decksQty);
        }

        // props
        public int Money { get { return money; } }
        public int GameNumber { get { return gameNomber; } }
        public int Bet  { get { return bet; } }
        public int CardCount { get { return shoes.Count; } }
        public Card GetNextCard { get { return shoes.GetNextCard(); } }
        public string GetPlayerName { get { return player.Name; } }
        //mthds
        public void MakeABet() {
            while (true)
            {
                Console.Write("Place your bet. ({0}$ available) : ", Money);
                int newBet;
                if (int.TryParse(Console.ReadLine(), out newBet))
                {
                    if (newBet < 1)
                    {
                        Console.WriteLine(new string('-', 20) + "\nError:\nU can't set negative or zero bet!");
                        Console.Write("Try to enter your bet againg: ");
                    }
                    else if (money - newBet < 0)
                    {
                        Console.WriteLine(new string('-', 20) + "\nError:\nU dont have much money");
                        Console.Write("Try to enter your bet again: ");
                    }
                    else
                    {
                        money -= bet = newBet;
                        return;
                    }
                }
                else Console.WriteLine("\n" + new string('-', 20) + "\nError:\nEnter number value");
            }
        }
        public void Start()
        {
            Console.Clear();
            do
            {     
                gameNomber++;
                MakeABet();

                this.PrintGameStats();
            }
            while (money > 0);

            ConsoleCommand.NoMoneyMessage();
        }
    }
}
