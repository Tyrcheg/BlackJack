using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Dealer : BasePlayersClass
    {
        private static readonly Dealer dealer = new Dealer();

        private Dealer()
        { Name = "Dealer"; }

        public static Dealer GetDealer { get { return dealer; } }
    }
}
