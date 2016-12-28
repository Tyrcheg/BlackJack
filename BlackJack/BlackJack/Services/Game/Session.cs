using System;
using System.Text;
using BlackJack.Services;

namespace BlackJack
{
    class Session
    {
        public void Start()
        {

            var player = PlayerServ.CreateAPlayer(ConsoleCommand.PlayersNameEnter());

            while (ConsoleCommand.StartANewGame())
            {
                Console.Clear();

                PlayerServ.DepositEnter(player);

                short decksQty = 1;

                new Game(decksQty, player).StartGame();

                ConsoleCommand.NoMoneyMessage();
            }

            ConsoleCommand.GameEnd();
        }
    }
}
