using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Session
    {
        Player player;

        public void Start()
        {
            player = new Player(ConsoleCommand.PlayersNameEnter());

            while (true)
            {
                if (ConsoleCommand.StartANewGame())
                {
                    Console.Clear();
                    int money = 10; short decksQty = 1;
                    try
                    {

                        //Console.Write("Enter number of decks: "); // количество колод в игре
                        //decksQty = short.Parse(Console.ReadLine());
                        decksQty = 1;
                    }
                    catch (Exception e)
                    { Console.WriteLine(e.Message); }

                    Game game = new Game(money, decksQty);

                    game.Start();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Thanx for game! Goodluck!");
                    break;
                }
            }
        }
    }
}
