using System;
using System.Collections.Generic;
using CardPhun.Card;
using CardPhun.Player;

namespace CardPhun.Game
{
    public abstract class GameBase<TPlayer, TDealer, TCard, TCardset> where TPlayer : Shark<TCard, TCardset>
        where TDealer : Dealer<TCard, TCardset>
        where TCard : Card.Card, new()
        where TCardset : CardSet<TCard>, new()
    {
        public List<TPlayer> Players { get; private set; }

        protected TDealer Dealer { get; private set; }

        protected TCardset Decks { get; private set; }

        protected void AddPlayer(TPlayer shark)
        {
            if (Players == null)
                Players = new List<TPlayer>();

            Players.Add(shark);
        }

        protected void SetDealer(TDealer dealer)
        {
            Dealer = dealer;
        }

        protected void SetInitialCards(int numberOfDecks)
        {
            if (numberOfDecks < 1)
                throw new ArgumentException("Number of decks has to be greater than 0");
            Decks = new TCardset();

            for (var i = 0; i < numberOfDecks; i++)
                Decks.AddSet(new CardDeck<TCard>(false));
            Decks.Shuffle();
        }

        protected void DealCards(int numberOfCards, bool includeDealer)
        {
            for (var i = 0; i < numberOfCards; i++)
            {
                foreach (var player in Players)
                    player.Cards.AddToSet(Decks.PopFromSet());

                if (includeDealer)
                    Dealer.Cards.AddToSet(Decks.PopFromSet());
            }
        }

        protected void DealCardsDealer()
        {
            Dealer.Cards.AddToSet(Decks.PopFromSet());
        }
    }
}