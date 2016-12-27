using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Services
{
    static class PlayerServices
    {
        public static Player CreateAPlayer(string _name)
        {
            //Player player = new Player();
            //player.Name = _name;
            //return player;
            return new Player() { Name = _name};
        }

        public static void MakeABet(Player player)
        { player.Money -= player.CurrentBet = ConsoleCommand.BetEnter(player.Money); }

        public static void DepositEnter(Player player, int deposit)
        { player.Money = deposit; }

        public static int GetPoints(BasePlayersClass player)
        {
            int points = 0;
            foreach (Card card in player.Cards)
                points += CardServices.GetCardValue(card);

            return points;
        }

        public static void AddCard(BasePlayersClass pl, Card card)
        { pl.Cards.Add(card); }
        public static void ClearCards(BasePlayersClass player)
        { player.Cards = new List<Card>(); }
    }
}
