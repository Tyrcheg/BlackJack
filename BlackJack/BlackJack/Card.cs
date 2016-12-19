using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    enum Suit
    {
        Hearts = 3, Diamonds = 4, Clubs = 5, Spades = 6
    }
    
    enum CardName
    {
        TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK = 10, QUEEN = 10, KING = 10 , ACE = 11
    }
    class Card
    {
        Suit suit;
        CardName cardName;
        public Card(CardName _cardName, Suit _suit)
        {
            cardName = _cardName; suit = _suit;
        }

        public int GetCardValue()
        {
            return (int)cardName;
        }
        public override string ToString()
        {
            return $"{cardName}{(char)suit}";
        }

    }
}

//Card card = new Card(CardName.FIVE, Suit.Clubs);
//Console.WriteLine(card.ToString());
//Console.WriteLine((int)CardName.JACK + " " + (int)CardName.KING);
//Console.WriteLine((int)CardName.FIVE);