using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardPhun;
using Stefan2;
using Stefan2.BlackJack;

namespace BlackJack
{
    public class BjCardSet : CardSet<BjCard>
    {
        public BjCardSet() 
        {
            _mCards = new List<BjCard>();
        }

        public BjCardSet(List<BjCard> cards)
        {
            _mCards = cards;
        }


        public override int GetSumOfCards()
        {
            int retVal = _mCards.Sum(card => card.Value);
            var numOfAces = 0;
            for (int i = 0; i < _mCards.Count(card => card.IsAce); i++)
            {
                retVal -= 10;
                numOfAces++;
            }
            if (retVal > 21)
            {
                return -1;              //necu nista da diram da ne sjebem, ali mislim da ovo ove pravi problem
            }
            if (retVal < 12)
            {
                for (int i = 0; i < numOfAces; i++)
                {
                    retVal += 10;
                    if (retVal > 11)
                    {
                        break;          //ne razumem zasto je ovde break
                    }
                }
            }

            return retVal;
        }

        //napraviti override za card sum za slike




    }
}
