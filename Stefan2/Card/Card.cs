using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardPhun
{


    public abstract class Card
    {

        public Card()
        {
            
        }

        //private int _mNumber;

        //public int Number
        //{
        //    get
        //    {
        //        return _mNumber;
        //    }
        //    set
        //    {
        //        _mNumber = value;
        //    }
        //}

        public Card(int number, Znak suit)
        {
            Number = number;
            Suit = suit;
        }

        public virtual int Number { get; set; }
        public Znak Suit { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Number, Suit);
        }

        public bool IsAce
        {
            get { return Number == 11; }
        }

        public bool IsPic
        {
            get { return Number > 11; }
        }

        public abstract int Value { get; }
    }

    public enum Znak
    {
        CLUBS = 0,
        HEARTS,
        SPADES,
        DIAMONDS
    }
}
