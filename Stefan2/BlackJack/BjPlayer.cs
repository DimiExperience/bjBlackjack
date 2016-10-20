using CardPhun.Player;

namespace CardPhun.BlackJack
{
    public class BjPlayer : Shark<BjCard, BjCardSet>
    {
        public BjPlayer(string name, int balance) : base(name, balance)
        {
        }
    }
}