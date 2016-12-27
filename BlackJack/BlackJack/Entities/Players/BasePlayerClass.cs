using BlackJack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    abstract class BasePlayersClass
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();
   
    }
}
