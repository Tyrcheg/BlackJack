using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Card
    {
        CardSuit suit;
        CardName cardName;
        public Card(CardName _cardName, CardSuit _suit)
        {
            cardName = _cardName;
            suit = _suit;
        }
        public int GetCardValue
        {
            get  {  return ((int)cardName < 12) ? (int)cardName : 10;   } 
        }
        public override string ToString()
        {
            return ((int)cardName < 11) ? $"{(int)cardName}{(char)suit}" : $"{cardName}{(char)suit}";
        }

    }
}
