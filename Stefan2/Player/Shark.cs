namespace Stefan2.Player
{
    public abstract class Shark<T_CARD, T_CARDSET> : Dealer<T_CARD, T_CARDSET>
        where T_CARD : Card
        where T_CARDSET : CardSet<T_CARD>, new()
    {
        protected Shark(string name, int balance) : base(name)
        {
            Balance = balance;
        }
        public int Balance { get; protected set; }

    }
}