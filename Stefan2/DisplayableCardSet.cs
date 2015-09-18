using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardPhun;

namespace Stefan2
{
    public class DisplayableCardSet : CardSet
    {

        private readonly int mNumberToHide;
        public DisplayableCardSet(CardSet cardSet, int numberOfHiddenCards)
        {
            mNumberToHide = numberOfHiddenCards;
            _mCards = cardSet.GetCardList();
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            var cardCount = _mCards.Count + 1;
            foreach (var card in _mCards)
            {
                cardCount--;
                sb.AppendFormat("{0}, ", cardCount < mNumberToHide ? "X" : card.ToString());
            }
            return sb.ToString().TrimEnd(',');
        }
    }
}
