using System.Collections.Generic;
using System.Linq;
using CardPhun.Card;

namespace CardPhun.BlackJack
{
    public sealed class BjCardSet : CardSet<BjCard>
    {
        public BjCardSet()
        {
            MCards = new List<BjCard>();
        }

        public BjCardSet(List<BjCard> cards)
        {
            MCards = cards;
        }


        public int GetSumOfCards()
        {
            var retVal = MCards.Sum(card => card.Value);
            var numOfAces = 0;
            for (var i = 0; i < MCards.Count(card => card.IsAce); i++)
            {
                retVal -= 10;
                numOfAces++;
            }
            if (retVal > 21)
            {
                return -1;
            }
            if (retVal < 12)
                for (var i = 0; i < numOfAces; i++)
                {
                    retVal += 10;
                    if (retVal > 11)
                        break;
                }

            return retVal;
        }
    }
}