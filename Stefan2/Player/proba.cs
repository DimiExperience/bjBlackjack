using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardPhun;
using Player;

namespace CardPhun.Player
{
    public class Proba<T_CARD, T_CARDSET> : Dealer<T_CARD, T_CARDSET> where T_CARD : Card where T_CARDSET : CardSet<T_CARD>, new()
    {
        public Proba(string name) : base(name)
        {
        }
    }
}
