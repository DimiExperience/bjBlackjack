using System;
using System.Linq;
using CardPhun.Game;
using CardPhun.BlackJack;

namespace BlackJack
{
    public class BjGame : GameBase<BjPlayer, BjDealer, BjCard, BjCardSet>
    {
        private readonly int _numberOfDecks;

        public BjGame(int numberOdDecks, int initBalance, string dealerName, params string[] playerNames)
        {
            //TODO: Check parameters
            _numberOfDecks = numberOdDecks;
            SetInitialCards(numberOdDecks);
            SetDealer(new BjDealer(dealerName));

            for (var i = 0; i < playerNames.Length; i++)
                AddPlayer(new BjPlayer(playerNames.ElementAt(i), initBalance));
        }

        public string Decision { get; set; }


        public override void Play()
        {
            foreach (var player in Players)
            {
                if (player.Balance == 0)
                {
                    //TODO: DELETE PLAYER! for now its just gonna get out of game...(in program.cs)
                }
                Console.WriteLine("Player {0}: How much you wanna bet? Balance: {1}?", player.Name, player.Balance);
                player.Bet = Math.Abs(Convert.ToInt32(Console.ReadLine()));
                    //TODO: Fix if someone inputs letter instead of number
                while ((player.Bet > player.Balance) || (player.Bet == 0))
                {
                    Console.WriteLine("Wrong input, try again");
                    player.Bet = Math.Abs(Convert.ToInt32(Console.ReadLine()));
                }
                player.Balance -= player.Bet;
            }

            if (Decks.GetSumOfCards() < 0)
                SetInitialCards(_numberOfDecks);

            Dealer.Cards.GetCardList().Clear();
            foreach (var player in Players)
                player.Cards.GetCardList().Clear();
            DealCards(2, true);
            PrintPlayers();

            var dealersCards = Dealer.Cards;

            PrintDealerHiddenCard();

            foreach (var player in Players)
            {
                if (player.Cards.GetSumOfCards() == 21)
                {
                    Console.WriteLine("Player BLACKJACK");
                    continue;
                }
                var nextStep = ContinuePlay(player);
                while (nextStep == NextMove.KeepPlaying)
                {
                    DealCards(1, false);
                    PrintPlayers();
                    nextStep = ContinuePlay(player);
                }

                if (nextStep == NextMove.Busted)
                    Console.WriteLine("You are busted");
                if (nextStep == NextMove.BlackJack)
                    Console.WriteLine("BLACKJACK");
                if (nextStep == NextMove.Stayed)
                {
                    Console.WriteLine("STAYED");

                    if (player.Cards.GetSumOfCards() >= 17)
                        Console.WriteLine("Wise decision, STAYED");
                }

                Decision = nextStep.ToString();
            }

            Console.WriteLine("Dealer cards {0}", dealersCards);

            while ((dealersCards.GetSumOfCards() < 17) && (dealersCards.GetSumOfCards() > 0))
            {
                DealCardsDealer(true);
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

        private NextMove ContinuePlay(BjPlayer player)
        {
            var sumOfCards = player.Cards.GetSumOfCards();

            if ((sumOfCards > 21) || (sumOfCards < 0))
                return NextMove.Busted;


            if (sumOfCards == 21)
                return NextMove.BlackJack;

            Console.Write("{0}: Hit (H) / Stay (S)?", player.Name);

            var userResponse = Console.ReadLine();


            if (string.Equals(userResponse, "s", StringComparison.InvariantCultureIgnoreCase))
                return NextMove.Stayed;


            return NextMove.KeepPlaying;
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

        private enum NextMove
        {
            Stayed,
            BlackJack,
            Busted,
            KeepPlaying
        }


        private enum PlayerChoice
        {
            None,
            Hit,
            Stay
        }
    }
}