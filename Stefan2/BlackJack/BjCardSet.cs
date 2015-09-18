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
                if (card.IsAce)
                {
                    retVal -= 10;
                    numOfAces++;
                }
            }
            if (retVal > 21)
            {
                return -1;
            }
            if (retVal < 12)
            {
                for (int i = 0; i < numOfAces; i++)
                {
                    retVal += 10;
                    if (retVal > 11)
                    {
                        break;
                    }
                }
            }

            return retVal;
        }
    }
}
