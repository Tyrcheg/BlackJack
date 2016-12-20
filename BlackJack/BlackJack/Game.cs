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
        Shoes shoes;

        // ctors
        public Game(int _money, short decksQty)
        {
            if (decksQty < 1 && decksQty > 4)
                throw new Exception("Invalid input for shoes");
            else if (_money <= 0)
                throw new Exception("Invalid input for deposit");

            money = _money;
            shoes = new Shoes(decksQty);
        }

        // props
        public int Money { get { return money; } }
 
        //mthds
        void MakeABet(int newBet)
        {
            if (newBet < 1)
            {
                Console.WriteLine(new string('-', 20) + "\nError:\nU can't set negative or zero bet!");
                Console.Write("Try to enter your bet againg: ");
                MakeABet(int.Parse(Console.ReadLine())); // можно и оверфлоу словить 
                newBet = 0;
            }
            else if (money - newBet < 0)
            {
                Console.WriteLine(new string('-', 20) + "\nError:\nU dont have much money");
                Console.Write("Try to enter your bet again: ");
                MakeABet(int.Parse(Console.ReadLine())); // можно и оверфлоу словить [2]
                newBet = 0;
            }
            else
                money -= bet = newBet; 
        }

        public void Start()
        {
            Console.Clear();
            do
            {
                Console.Write("Place your bet. ({0}$ available) : ", Money);
                var newBet = int.Parse(Console.ReadLine());
                MakeABet(newBet);

                gameNomber++;

                PrintGameStats();

                //shoes.PrintAllCards();
            }
            while (money > 0);

            Console.WriteLine(new string('!', 28));
            Console.WriteLine("You have lost all your money");
            Console.WriteLine(new string('!', 28) + "\n");
        }

        public void PrintGameStats()
        {
            Console.Clear();
            //Console.WriteLine("Players' name: {0}", Player.Name);
            Console.WriteLine(new string('-', 20) + "\nYour cash: {0}$", money);
            Console.WriteLine(new string('-', 20) + "\nGame #{0}", gameNomber);
            Console.WriteLine("Current bet: {0}$", bet);
            Console.WriteLine("Cards in deck: {0}", shoes.Count);
            Console.WriteLine("Current card: {0}", shoes.GetNextCard().ToString());

            Console.WriteLine(new string('-', 20));
        }

    }
}
