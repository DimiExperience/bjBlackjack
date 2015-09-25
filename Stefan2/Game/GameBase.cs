using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player;

namespace CardPhun.Game
{
    public abstract class GameBase
    {
        public List<Shark> Players { get; private set; }

        public Dealer Dealer { get; private set; }

        public CardSet Decks { get; private set; }

        protected void AddPlayer(Shark shark)
        {
            if (Players == null)
            {
                Players = new List<Shark>();
            }

            Players.Add(shark);
        }

        protected void SetDealer(Dealer dealer)
        {
            Dealer = dealer;
        }

        protected void SetInitialCards(int numberOfDecks)
        {
            if (numberOfDecks < 1)
            {
                throw new ArgumentException("Number of decks has to be greater than 0");
            }
            Decks = new CardSet();

            for (var i = 0; i < numberOfDecks; i++)
            {
                Decks.AddSet(new CardDeck(false));
            }
            Decks.Shuffle();
        }

        protected void DealCards(int numberOfCards, bool includeDealer)
        {
            for (var i = 0; i < numberOfCards; i++)
            {
                foreach (var player in Players)
                {
                    player.Cards.AddToSet(Decks.PopFromSet());
                }

                if (includeDealer)
                {
                    Dealer.Cards.AddToSet(Decks.PopFromSet());
                }
            }
        }

        protected void DealCardsDealer(bool dealDealer)
        {
            Dealer.Cards.AddToSet(Decks.PopFromSet());
        }

        public abstract void Play();
    }
}

public enum CardCompare
{
    WORSE = 0,
    EQUAL,
    BETTA
}
