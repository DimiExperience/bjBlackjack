using System;
using CardPhun.Card;

namespace CardPhun.Player
{
    public abstract class Dealer<TCard, TCardset> where TCard : Card.Card where TCardset : CardSet<TCard>, new()
    {
        private TCardset _mCards;

        protected Dealer(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public string Name { get; private set; }

        public TCardset Cards => _mCards ?? (_mCards = new TCardset());
    }
}