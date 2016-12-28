using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Services
{
    static class ShoesServ
    {
        public const int CARDSINDECK = 52;

        public static Shoes CreateShoes(short quantity)
        {
            Shoes shoes = new Shoes();
            return Initialize(shoes, quantity);
        }

        public static int CountCardsInShoes(Shoes shoes)
        {
            return shoes.Decks.Count();
        }

        static Shoes Initialize(Shoes shoes, short quantity)
        {
            //shoes = new Stack<Card>(CARDSINDECK * decksNo);
            List<Card> pack = new List<Card>(CARDSINDECK * quantity);

            for (int i = (int)CardSuit.Hearts; i <= (int)CardSuit.Spades; i++)
            {
                for (int j = (int)CardName.TWO; j <= (int)CardName.TEN; j++)
                    pack.Insert(new Random().Next(0, pack.Count), CardServ.CreateACard((CardName)j, (CardSuit)i));

                pack.Insert(new Random().Next(0, pack.Count), CardServ.CreateACard(CardName.K, (CardSuit)i));
                pack.Insert(new Random().Next(0, pack.Count), CardServ.CreateACard(CardName.J, (CardSuit)i));
                pack.Insert(new Random().Next(0, pack.Count), CardServ.CreateACard(CardName.Q, (CardSuit)i));
                pack.Insert(new Random().Next(0, pack.Count), CardServ.CreateACard(CardName.A, (CardSuit)i));
            }

            for (int i = 0; i < CARDSINDECK; i++)
            {
                int r = new Random().Next(0, CARDSINDECK);
                var buff = pack[i];
                pack[i] = pack[r];
                pack[r] = buff;
            }

            for (int i = 0; i < CARDSINDECK; i++)
            {
                int r = new Random().Next(0, pack.Count - 1);
                shoes.Decks.Push(pack.ElementAt(r));
                pack.RemoveAt(r);
            }

            return shoes;


            //foreach (var item in shoes) Console.Write(item.ToString() + " "); Console.ReadKey();
        }

        public static Card GetNextCard(Shoes shoes)
        {
            return (shoes.Decks.Count > 0) ? shoes.Decks.Pop() : null;
        }

    }
}
