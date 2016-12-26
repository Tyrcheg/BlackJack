using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    abstract class BasePlayersClass
    {
        public string Name { get; protected set; }

        List<Card> cards = new List<Card>();

        public int GetPoints()
        {
            int points = 0;
            foreach (Card card in cards)
                points += card.GetCardValue;

            return points;
        }
        
        public void AddCard(Card card)
        {
            cards.Add(card);
        }
        public void ClearCards()
        {
            cards = new List<Card>();
        }

        public void PrintCurrentCards()
        {
            foreach (Card card in cards)
                Console.Write(card.ToString() + " ");
            Console.WriteLine();
        }   

    }
}
