using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    // Class for future implementation
   class Player
   {
        public string Name { get; set; }
        Dictionary<int, string> betHistory = new Dictionary<int, string>();

        public Player(string _name)
        {
            Name = _name;
        }


    }
}
