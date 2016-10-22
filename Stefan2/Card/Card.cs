namespace CardPhun.Card
{
    public abstract class Card
    {
        protected Card()
        {
        }


        protected Card(int number, Znak suit)
        {
            Number = number;
            Suit = suit;
        }

        public int Number { get; set; }
        public Znak Suit { private get; set; }

        public bool IsAce => Number == 11;

        protected bool IsPic => Number > 11;

        public abstract int Value { get; }

        public override string ToString()
        {
            return $"{Number} {Suit}";
        }
    }

    public enum Znak
    {
        Spades,
        Hearts,
        Clubs,
        Diamonds
    }
}