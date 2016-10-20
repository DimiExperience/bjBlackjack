using CardPhun.Card;

namespace CardPhun.BlackJack
{
    public class BjCard : Card.Card
    {
        public BjCard(int number, Znak suit) : base(number, suit)
        {
        }

        public BjCard()
        {
        }

        public override int Value => IsPic ? 10 : Number;
    }
}