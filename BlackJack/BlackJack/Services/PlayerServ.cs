using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Services
{
    static class PlayerServ
    {
        public static Player CreateAPlayer(string _name)
        {
            return new Player() { Name = _name};
        }

        public static void MakeABet(Player player)
        {
            player.Money -= player.CurrentBet = ConsoleCommand.BetEnter(player.Money);
        }

        public static void DepositEnter(Player player)
        { player.Money = ConsoleCommand.DepositEnter(); }

        public static int GetPoints(BasePlayersClass player)
        {
            int points = 0;
            foreach (Card card in player.Cards)
                points += CardServ.GetCardValue(card);

            return points;
        }

        public static void AddCard(BasePlayersClass pl, Card card)
        { pl.Cards.Add(card); }

        public static void ClearCards(BasePlayersClass player)
        { player.Cards = new List<Card>(); }
    }
}
