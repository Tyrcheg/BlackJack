using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Services
{
    static class CardServ
    {
        public static Card CreateACard(CardName _cardName, CardSuit _cardSuit)
        {
            return new Card() { Name = _cardName, Suit = _cardSuit };
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
