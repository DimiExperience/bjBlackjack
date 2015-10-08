using System.Linq;

namespace Stefan2
{
    public class CardDeck<T> : CardSet<T> where T : Card, new()
    {
        public CardDeck(bool shuffleIt = true) //Constructor. Executes when you make a new instance (object) of this class.
        {
            for (int i = 2; i <= 14; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var znak = (Znak)j;
                    var karta = new T();
                    karta.Number = i;
                    karta.Suit = znak;
                    AddToSet(karta);
                }
            }
            if (shuffleIt)
            {
                Shuffle();
            }
        }

        public override int GetSumOfCards()
        {
            return _mCards.Sum(card => card.Value);
        }
    }
}
