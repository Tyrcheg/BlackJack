using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            var player = Player.GetInstanceOfPlayer(name);

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            var player = Player.GetInstanceOfPlayer(name);

            while (true)
            {
                Console.WriteLine("Do you want to start a new game y/n?");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes" || answer == "y" || answer == "н")
                {
                    Console.Clear();
                    int money = 10; short decksQty = 1;
                    try
                    {
                        Console.Write("Enter your deposit: ");
                        money = int.Parse(Console.ReadLine());
                        //Console.Write("Enter number of decks: "); // количество колод в игре
                        //decksQty = short.Parse(Console.ReadLine());
                        decksQty = 1;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

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
