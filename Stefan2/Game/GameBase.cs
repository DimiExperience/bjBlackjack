using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player;

namespace CardPhun.Game
{
    public abstract class GameBase<T_PLAYER, T_DEALER, T_CARD, T_CARDSET> where T_PLAYER : Shark<T_CARD, T_CARDSET> where T_DEALER : Dealer<T_CARD, T_CARDSET> where T_CARD : Card, new() where T_CARDSET : CardSet<T_CARD>, new()
    {
        public List<T_PLAYER> Players { get; private set; }

        public T_DEALER Dealer { get; private set; }

        public T_CARDSET Decks { get; private set; }

        protected void AddPlayer(T_PLAYER shark)
        {
            if (Players == null)
            {
                Players = new List<T_PLAYER>();
            }

            Players.Add(shark);
        }

        protected void SetDealer(T_DEALER dealer)
        {
            Dealer = dealer;
        }

        protected void SetInitialCards(int numberOfDecks)
        {
            if (numberOfDecks < 1)
            {
                throw new ArgumentException("Number of decks has to be greater than 0");
            }
            Decks = new T_CARDSET();

            for (var i = 0; i < numberOfDecks; i++)
            {
                Decks.AddSet(new CardDeck<T_CARD>(false));
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
