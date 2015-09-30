using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardPhun;

namespace Stefan2.BlackJack
{
    public class BjCard : Card
    {
        public BjCard(int number, Znak suit) : base(number, suit)
        {
        }

        public BjCard()
        {
            
        }

        public override int Value
        {
            get
            {
                return IsPic ? 10 : Number;
            }
        }
    }
}
