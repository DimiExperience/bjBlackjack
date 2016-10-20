using System;
using CardPhun.Card;

namespace CardPhun.Player
{
    public abstract class Dealer<TCard, TCardset> where TCard : Card.Card where TCardset : CardSet<TCard>, new()
        //zasto T_CARD and so on... ali mislim da sam skapirao... T_CARD je Card, gde je T_SET od cardset od T_CARD sto dalje vodi do card, right... e sada zasto? zar niej moglo odmah da se uradi card i cardset?
    {
        private TCardset _mCards; // sta?

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