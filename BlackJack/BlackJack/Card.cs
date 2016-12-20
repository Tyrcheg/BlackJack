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
            cardName = _cardName; suit = _suit;
        }
        public int GetCardValue
        {
            get
            {
                if ((int)cardName < 12)
                    return (int)cardName;

                    return 10;
            } // можно и методом. но так не надо лишних скобок писать
        }
        public override string ToString()
        {
            if((int)cardName < 11)
                return $"{(int)cardName}{(char)suit}";
            return $"{cardName}{(char)suit}";

        }

    }
}
