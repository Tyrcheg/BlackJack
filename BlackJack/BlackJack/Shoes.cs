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

        //
        public int Count { get { return shoes.Count - 1;  } }
        
        //void ShoesInitialize()
        //{

        //    // заполняем колоду
        //    ushort[] list = new ushort[52]; 
        //    shoes = new Stack<ushort>(52 * decksNo);
        //    for (ushort i = 0; i < 52; i++)
        //        list[i] = i;

        //    // тасовка колоды
        //    var rand = new Random(DateTime.Now.Millisecond);
        //    list = list.OrderBy(x => rand.Next()).ToArray();
        //    // второй вариант
        //    for (ushort j = 0; j < 52 * decksNo; j++)
        //    {
        //        var x = new Random().Next(j, list.Length);
        //        shoes.Push(list[x]);

        //        var buf = list[j];
        //        list[j] = list[x];
        //        list[x] = buf;
        //    }
        //}

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
                int r = new Random().Next(0, pack.Count -1);
                shoes.Push(pack.ElementAt(r));
                pack.RemoveAt(r);
            }

            // foreach (var item in shoes) Console.Write(item.ToString() + " ");   Console.ReadKey();
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

