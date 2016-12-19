using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{

    class Shoes
    {
        //List<Card> shoes = new List<Card>();
        short decksNo; // количество колод в шузе
        /*List<ushort> shoes = new List<ushort>();*/
        Stack<ushort> shoes;
        List<Card> pack = new List<Card>(52);

        public Shoes(short quantity)
        {
            decksNo = quantity;
            ShoesInitialize();
        }

        void ShoesInitialize()
        {

            // заполняем колоду
            ushort[] list = new ushort[52]; 
            shoes = new Stack<ushort>(52 * decksNo);
            for (ushort i = 0; i < 52; i++)
                list[i] = i;

            // тасовка колоды
            var rand = new Random(DateTime.Now.Millisecond);
            list = list.OrderBy(x => rand.Next()).ToArray();
            // второй вариант
            for (ushort j = 0; j < 52 * decksNo; j++)
            {
                var x = new Random().Next(j, list.Length);
                shoes.Push(list[x]);

                var buf = list[j];
                list[j] = list[x];
                list[x] = buf;
            }
        }

        public ushort GetNextCard()
        {
            if (shoes.Count > 0)
                return shoes.Pop();

            return ushort.MaxValue; // ну тип как минус один тип фолс возвращает, только тут максвалюе возвращает
        }

        public void PrintAllCards()
        {
            foreach (var item in shoes)
            {
                Console.WriteLine(GetCardName(item));
            }
        }

        public string GetCardName(ushort number)
        {
            if (number == ushort.MaxValue)
                return "Deck is over!";

            double suit = (double)number / 4;
            if (suit < 3)
                return $"{number % 13 + 2}{(char)3}";
            else if (suit < 6)
                return $"{number % 13 + 2}{(char)4}";
            else if (suit < 9)
                return $"{number % 13 + 2}{(char)5}";
            else
                return $"{number % 13 + 2}{(char)6}";
        }

        public int CountCards()
        {
            return shoes.Count;
        }
    }
}

