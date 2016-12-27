using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Services
{
    static class CardServices
    {
        public static Card CreateACard(CardName _cardName, CardSuit _cardSuit)
        {
            var card = new Card();
            card.Name = _cardName;
            card.Suit = _cardSuit;
            return card;
        }
        public static int GetCardValue(Card card)
        {
            return ((int)card.Name < (int)CardName.A) ? (int)card.Name : 10; 
        }
        public static string GetFullCardName(Card card)
        {
            return ((int)card.Name < (int)CardName.A) ? $"{(int)card.Name}{(char)card.Suit }" : $"{card.Name}{(char)card.Suit }";
        }
    }
}
