using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player;
using Stefan2.BlackJack;

namespace BlackJack
{
    public class BjDealer : Dealer<BjCard, BjCardSet>
    {
        public BjDealer(string name) : base(name) { }
    }
}
