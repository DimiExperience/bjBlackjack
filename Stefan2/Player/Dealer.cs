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

        public CardSet Cards { get; protected set; }


    }
}
