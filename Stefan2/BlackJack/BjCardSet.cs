using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardPhun;
using Stefan2;

namespace BlackJack
{
    class BjCardSet : DisplayableCardSet
    {
        public BjCardSet(CardSet cardSet, int numOfCardsToHide) : base(cardSet, numOfCardsToHide)
        {
            
        }

        public override int GetSumOfCards()
        {
            var retVal = base.GetSumOfCards();
            var numOfAces = 0;
            foreach (var card in _mCards)
            {
                if (card.IsPic)
                {
                    retVal -= 10;
                    numOfAces++;
                }
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
