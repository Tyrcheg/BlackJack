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

        //Stack<ushort> shoes;
        Stack<Card> shoes;

        public Shoes(short quantity)
        {
            decksNo = quantity;
            Initialize();
        }

        //
        public int Count { get { return shoes.Count;  } }
        
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

            for (int i = 3; i <= 6; i++)
            {
               // for (int j = 2; j <= 10; j++)
                for (int j = (int)CardName.TWO; j <= (int)CardName.TEN; j++)
                    pack.Insert(new Random().Next(0, pack.Count), new Card((CardName)j, (Suit)i));

                pack.Insert(new Random().Next(0, pack.Count), new Card(CardName.J, (Suit)i));
                pack.Insert(new Random().Next(0, pack.Count), new Card(CardName.Q, (Suit)i));
                pack.Insert(new Random().Next(0, pack.Count), new Card(CardName.K, (Suit)i));
                pack.Insert(new Random().Next(0, pack.Count), new Card(CardName.A, (Suit)i));
            }

            // Pack look up [1]
            // foreach (var item in pack)    Console.Write(item.ToString() + " ");
            // Console.ReadLine();

            // second shuffle
            for (int i = 0; i < 52; i++)
            {
                int r = new Random().Next(0, pack.Count -1);
                shoes.Push(pack.ElementAt(r));
                pack.RemoveAt(r);
            }

            // Pack look up[2]
            // foreach (var item in shoes) Console.Write(item.ToString() + " ");
            // Console.ReadLine();
        }

        public Card GetNextCard()
        {
            if (shoes.Count > 0)
                return shoes.Pop();

            return null;
        }
        
        public void PrintAllCards()
        {
            foreach (Card card in shoes)
                Console.WriteLine(card.ToString());
        }

        // для старого стека с целыми числами
        //public string GetCardName(ushort number)
        //{
        //    if (number == ushort.MaxValue)
        //        return "Deck is over!";

        //    double suit = (double)number / 4;
        //    if (suit < 3)
        //        return $"{number % 13 + 2}{(char)3}";
        //    else if (suit < 6)
        //        return $"{number % 13 + 2}{(char)4}";
        //    else if (suit < 9)
        //        return $"{number % 13 + 2}{(char)5}";
        //    else
        //        return $"{number % 13 + 2}{(char)6}";
        //}


    }
}

