namespace CardPhun.BlackJack
{
    public static class BlackJackUtil //TODO: WTF? do we use this?
    {
        public static int GetBlackjackSum(BjCardSet set)
        {
            var numOfAces = 0;
            var retVal = 0;
            for (var i = 0; i < set.Count; i++)
            {
                var card = set.SeeCard(i);
                if (card.Number == 11)
                {
                    numOfAces++;
                    retVal++;
                }
                else if (card.Number > 11)
                {
                    retVal += 10;
                }
                else
                {
                    retVal += card.Number;
                }
            }
            for (var i = 0; i < numOfAces; i++)
                if (retVal < 12)
                    retVal += 10;
            return retVal;
        }
    }
}