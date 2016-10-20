namespace CardPhun.Card
{
    public sealed class CardDeck<T> : CardSet<T> where T : Card, new()
    {
        public CardDeck(bool shuffleIt = true)
        {
            for (var i = 2; i <= 14; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    var znak = (Znak)j;
                    var karta = new T
                    {
                        Number = i,
                        Suit = znak
                    };
                    AddToSet(karta);
                }
            }
            if (shuffleIt)
            {
                Shuffle();
            }
        }
    }
}
