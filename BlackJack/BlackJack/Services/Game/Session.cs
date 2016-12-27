using System;
using System.Text;
using BlackJack.Services;

namespace BlackJack
{
    class Session
    {
        public void Start()
        {

            Player player = PlayerServices.CreateAPlayer(ConsoleCommand.PlayersNameEnter());

            while (ConsoleCommand.StartANewGame())
            {
                Console.Clear();

                PlayerServices.DepositEnter(player, ConsoleCommand.DepositEnter());

                short decksQty = 1;

                new Game(decksQty, player).StartGame();

                ConsoleCommand.NoMoneyMessage();
            }

            ConsoleCommand.GameEnd();
        }
    }
}
