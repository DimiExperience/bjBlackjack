using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player;
using CardPhun.BlackJack;

namespace BlackJack
{
    public class BjDealer : Dealer<BjCard, BjCardSet>
    {
        public BjDealer(string name) : base(name) { }
    }
}
