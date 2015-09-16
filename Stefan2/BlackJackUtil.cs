using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardPhun
{
    using Toore.Shuffling;

    public static class BlackJackUtil
    {
        public static int GetBlackjackSum(CardSet set)
        {
            var numOfAces = 0;
            var retVal = 0;
            for (int i = 0;  i < set.Count; i++)
            {
                var card = set.SeeCard(i);
                if (card.Number == 11)
                {
                    numOfAces++;
                    retVal++;
                } else if (card.Number > 11)
                {
                    retVal += 10;
                }
                else
                {
                    retVal += card.Number;
                }
            }
            for (int i = 0; i < numOfAces; i++)
            {
                if (retVal < 12)
                {
                    retVal += 10;
                }
            }
            return retVal;
        }
    }
}
