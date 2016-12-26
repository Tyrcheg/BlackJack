using System;
using System.Text;

namespace BlackJack
{
    class Session
    {
        public void Start()
        {
            Player player = new Player(ConsoleCommand.PlayersNameEnter(), ConsoleCommand.DepositEnter());

            while (true)
            {
                if (ConsoleCommand.StartANewGame())
                {
                    Console.Clear();

                    short decksQty = 1;

                    new Game(decksQty, player).StartGame();
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
