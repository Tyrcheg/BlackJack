using System;
using System.Text;

namespace BlackJack
{
    class Session
    {
        public void Start()
        {
            Player player = new Player(ConsoleCommand.PlayersNameEnter());
            Player casino = new Player("Casino");

            while (true)
            {
                if (ConsoleCommand.StartANewGame())
                {
                    Console.Clear();

                    int money = ConsoleCommand.DepositEnter();

                    short decksQty = 1;

                    new Game(money, decksQty, player).Start();
                }
                else
                {
                    ConsoleCommand.GameEnd();
                    break;
                }
            }
        }
    }
}
