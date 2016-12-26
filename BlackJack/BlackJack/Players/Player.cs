using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Player : BasePlayersClass
    {
        public int CurrentBet { get; private set; }
        public int Money { get; set; }

        public Player(string _name, int _money)
        {
            Name = _name;
            Money = _money;
        }

        public void MakeABet()
        {
            while (true)
            {
                Console.Write("Place your bet. ({0}$ available) : ", Money);
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
                }
                if (Money - newBet < 0)
                {
                    Console.WriteLine(new string('-', 20) + "\nError:\nU dont have much money");
                    Console.Write("Try to enter your bet again: ");
                }

                Money -= CurrentBet = newBet;
                return;

            }
        }
    }



}

