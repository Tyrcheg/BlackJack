using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{

    class Shoes
    {
        short decksNo; // количество колод в шузе
        Stack<Card> shoes;

        public Shoes(short quantity)
        {
            decksNo = quantity;
            Initialize();
        }

        public int Count { get { return shoes.Count - 1; } }

        void Initialize()
        {
            shoes = new Stack<Card>(52 * decksNo);
            List<Card> pack = new List<Card>(52 * decksNo);

            for (int i = (int)CardSuit.Hearts; i <= (int)CardSuit.Spades; i++)
            {
                for (int j = (int)CardName.TWO; j <= (int)CardName.TEN; j++)
                    pack.Insert(new Random().Next(0, pack.Count), new Card((CardName)j, (CardSuit)i));

                pack.Insert(new Random().Next(0, pack.Count), new Card(CardName.J, (CardSuit)i));
                pack.Insert(new Random().Next(0, pack.Count), new Card(CardName.Q, (CardSuit)i));
                pack.Insert(new Random().Next(0, pack.Count), new Card(CardName.K, (CardSuit)i));
                pack.Insert(new Random().Next(0, pack.Count), new Card(CardName.A, (CardSuit)i));
            }

            // second shuffle
            for (int i = 0; i < 52; i++)
            {
                int r = new Random().Next(0, 52);
                var buff = pack[i];
                pack[i] = pack[r];
                pack[r] = buff;
            }

            //third shuffle
            for (int i = 0; i < 52; i++)
            {
                int r = new Random().Next(0, pack.Count - 1);
                shoes.Push(pack.ElementAt(r));
                pack.RemoveAt(r);
            }

            //foreach (var item in shoes) Console.Write(item.ToString() + " "); Console.ReadKey();
        }

        public Card GetNextCard()
        {
            return (shoes.Count > 0) ? shoes.Pop() : null;
        }

        public void PrintAllCards()
        {
            foreach (Card card in shoes)
                Console.WriteLine(card.ToString());
        }
    }
}

