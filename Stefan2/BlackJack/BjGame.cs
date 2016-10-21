using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using CardPhun.Game;

namespace CardPhun.BlackJack
{
    public class BjGame : GameBase<BjPlayer, BjDealer, BjCard, BjCardSet>
    {
        private readonly int _numberOfDecks;

        public BjGame(int numberOdDecks, int initBalance, string dealerName, params string[] playerNames)
        {
            _numberOfDecks = numberOdDecks;
            SetInitialCards(numberOdDecks);
            SetDealer(new BjDealer(dealerName));

            for (var i = 0; i < playerNames.Length; i++)
                AddPlayer(new BjPlayer(playerNames.ElementAt(i), initBalance));
        }

        private string Decision { get; set; }


        public virtual void Play()
        {
            for (var i = 0; i < Players.Count; i++)
            {
                if (Players[i].Balance == 0)
                {
                    Players.RemoveAt(i);
                }
            }
            foreach (var player in Players)
            {
                Console.WriteLine("Player {0}: How much you wanna bet? Balance: {1}?", player.Name, player.Balance);
                player.Bet = StringToInt(Console.ReadLine());
                while ((player.Bet > player.Balance) || (player.Bet == 0))
                {
                    Console.WriteLine("Wrong input, try again");
                    player.Bet = StringToInt(Console.ReadLine());

                }
                player.Balance -= player.Bet;
            }

            if (Decks.GetSumOfCards() < 0)
                SetInitialCards(_numberOfDecks);

            Dealer.Cards.GetCardList().Clear();
            foreach (var player in Players)
            {
                player.Cards.GetCardList().Clear();
            }
            DealCardsEveryone();
            PrintPlayers();

            var dealersCards = Dealer.Cards;

            PrintDealerHiddenCard();

            foreach (var player in Players)
            {
                if (player.Cards.GetSumOfCards() == 21)
                {
                    Console.WriteLine("{0} BLACKJACK", player.Name);
                    continue;
                }
                ContinuePlay(player);
                while (player.NextMove == NextMove.KeepPlaying)
                {
                    DealCards(1, false, player);
                    PrintPlayers();
                    ContinuePlay(player);
                }

                if (player.NextMove == NextMove.Busted)
                    Console.WriteLine("You are busted");
                if (player.NextMove == NextMove.BlackJack)
                    Console.WriteLine("BLACKJACK");
                if (player.NextMove == NextMove.Stayed)
                {
                    Console.WriteLine("STAYED");

                    if (player.Cards.GetSumOfCards() >= 17)
                        Console.WriteLine("Wise decision, STAYED");
                }

                Decision = player.NextMove.ToString();
            }

            Console.WriteLine("Dealer cards {0} SUM: {1}", dealersCards, dealersCards.GetSumOfCards());

            while ((dealersCards.GetSumOfCards() < 17) && (dealersCards.GetSumOfCards() > 0))
            {
                DealCardsDealer();
                PrintDealerAllCards();
            }

            if (dealersCards.GetSumOfCards() == 21)

                Console.WriteLine("Dealer BLACKJACK");

            foreach (var player in Players)
                if (Decision == "Stayed")
                    if (player.Cards.GetSumOfCards() > dealersCards.GetSumOfCards())
                    {
                        Console.WriteLine("Player {0} WINS", player.Name);
                        player.Balance += player.Bet*2;
                    }
                    else if ((player.Cards.GetSumOfCards() == 21) && (dealersCards.GetSumOfCards() == 21))
                    {
                        if (player.Cards.Count > 4)
                        {
                            Console.WriteLine("{0} WINS!", player.Name);
                            player.Balance += 2*player.Bet;
                        }
                        else
                        {
                            Console.WriteLine("Both dealer and {0} BLACKJACK", player.Name);
                            player.Balance += player.Bet;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Dealer WINS against {0}", player.Name);
                    }
        }

        private int StringToInt(string s)
        {
            try
            {
                var a = int.Parse(s);
                if (a > 0)
                {
                    return a;
                }
                else
                {
                    return 0;
                }
            }
            catch (FormatException)
            {
                return 0;
            }
        }


        public void ContinuePlay(BjPlayer player)
        {
            var sumOfCards = player.Cards.GetSumOfCards();

            if ((sumOfCards > 21) || (sumOfCards < 0))
            {
                player.NextMove = NextMove.Busted;
                return;
            }

            if (sumOfCards == 21)
            {
                player.NextMove = NextMove.BlackJack;
                return;
            }
            Console.Write("{0}: Hit (H) / Stay (S)?", player.Name);

            var userResponse = Console.ReadLine();


            if (string.Equals(userResponse, "s", StringComparison.InvariantCultureIgnoreCase))
            {
                player.NextMove = NextMove.Stayed;
                return;
            }
            if (string.Equals(userResponse, "h", StringComparison.InvariantCultureIgnoreCase))
            
                player.NextMove = NextMove.KeepPlaying;
            
        }

        private void PrintPlayers()
        {
            foreach (var player in Players)
                Console.WriteLine("{0}: {1} SUM: {2}", player.Name, player.Cards, player.Cards.GetSumOfCards());
        }

        private void PrintDealerHiddenCard()
        {
            Console.WriteLine("Dealer: {0} [HIDDEN]", Dealer.Cards.SeeCard(0));
        }

        private void PrintDealerAllCards()
        {
            Console.WriteLine("Dealer: {0} SUM: {1}", Dealer.Cards, Dealer.Cards.GetSumOfCards());
        }

        public enum NextMove
        {
            Stayed,
            BlackJack,
            Busted,
            KeepPlaying
        }
    }
}