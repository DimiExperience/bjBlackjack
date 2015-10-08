using System;

namespace Stefan2.Player
{
    public abstract class Dealer<T_CARD, T_CARDSET> where T_CARD : Card where T_CARDSET : CardSet<T_CARD>, new()
    {
        protected Dealer(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            Name = name;
        }

        public string Name { get; private set; }

        private T_CARDSET _mCards;

        public T_CARDSET Cards
        {
            get
            {
                if (_mCards == null) _mCards = new T_CARDSET();
                return _mCards;

            }
            protected set { _mCards = value; }
        }
    }


}
