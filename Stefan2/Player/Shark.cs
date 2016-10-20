using CardPhun.Card;

namespace CardPhun.Player
{
    public abstract class Shark<TCard, TCardset> : Dealer<TCard, TCardset>
        where TCard : Card.Card
        where TCardset : CardSet<TCard>, new()
    {
        protected Shark(string name, int balance) : base(name)
        {
            Balance = balance;
        }

        public int Balance { get; set; }
        public int Bet { get; set; }
    }
}