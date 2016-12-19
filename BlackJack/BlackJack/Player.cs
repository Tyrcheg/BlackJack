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
        static Player player;
   
        static string name;
        public static string Name { get { return name; } }

        private Player(string _name)
        {
            name = _name;
        }

        public static Player GetInstanceOfPlayer(string _name)
        {
            if (player == null)
                player = new Player(_name);
            return player;
        }


    }
}
