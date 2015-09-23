using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardPhun;

namespace Player
{
    public abstract class Dealer
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

        private CardSet _mCards;

        public CardSet Cards
        {
            get
            {
                if (_mCards == null) _mCards = new CardSet();
                return _mCards;

            }
            protected set { _mCards = value; }
        }
    }


}
