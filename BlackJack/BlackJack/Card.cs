using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    enum Suit
    {  Hearts = 3, Diamonds = 4, Clubs = 5, Spades = 6   }
    
    enum CardName
    {
        TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE,
        TEN, J = 10, Q = 10, K = 10 , A
    }
    class Card
    {
        Suit suit;
        CardName cardName;
        public Card(CardName _cardName, Suit _suit)
        {
            cardName = _cardName; suit = _suit;
        }
        public int GetCardValue
        {
            get { return (int)cardName; } // можно и методом. но так не надо лишних скобок писать
        }
        public override string ToString()
        {
            if((int)cardName < 11)
                return $"{(int)cardName}{(char)suit}";
            return $"{cardName}{(char)suit}";
        }

    }
}
