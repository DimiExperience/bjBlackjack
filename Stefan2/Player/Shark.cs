using System;
using CardPhun;

namespace Player
{
    public abstract class Shark : Dealer
    {
        protected Shark(string name, int balance) : base(name)
        {
            Balance = balance;
        }
        public int Balance { get; protected set; }
    }
}