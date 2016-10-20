using CardPhun.Player;

namespace CardPhun.BlackJack
{
    public class BjDealer : Dealer<BjCard, BjCardSet>
    {
        public BjDealer(string name) : base(name)
        {
        }
    }
}