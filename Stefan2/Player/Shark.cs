using System;
using CardPhun;
using CardPhun;

namespace Player
{
    public abstract class Shark<T_CARD, T_CARDSET> : Dealer<T_CARD, T_CARDSET>
        where T_CARD : Card
        where T_CARDSET : CardSet<T_CARD>, new()
    {
        protected Shark(string name, int balance) : base(name)
        {
            Balance = balance;
        }
        public int Balance { get; set; }
        public int Bet { get; set; }

    }
}