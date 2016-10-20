using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player;
using CardPhun.BlackJack;

namespace BlackJack
{
    public class BjPlayer : Shark<BjCard, BjCardSet>
    {
        public BjPlayer(string name, int balance) : base(name, balance)
        {
          

        }
        
    }
}
