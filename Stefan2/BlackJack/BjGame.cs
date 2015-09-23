using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BlackJack;
using CardPhun;
using CardPhun.Game;
using Player;
using Stefan2;

namespace BlackJack
{
    public class BjGame : GameBase
    {
        public BjGame(int numberOdDecks, int initBalance, string dealerName, params string[] playerNames)
        {
            //TODO: Check parameters

            SetInitialCards(numberOdDecks);
            SetDealer(new BjDealer(dealerName));

            for (var i = 0; i < playerNames.Length; i++)
            {
                AddPlayer(new BjPlayer(playerNames.ElementAt(i), initBalance));
            }
        }


        public override void Play()
        {
            DealCards(2, true);
            foreach (var player in Players)
            {
                Console.WriteLine("{0}: {1}", player.Name, player.Cards);
            }

            var dealersCards = new BjCardSet(Dealer.Cards, 1);

            Console.WriteLine("{0}: {1}", Dealer.Name, dealersCards);

            PLAYER_CHOICE playerChoice = PLAYER_CHOICE.None;

            foreach (var player in Players)
            {
                var nextStep = ContinuePlay(player);
                while (nextStep != NextMove.KeepPlaying)
                {
                    DealCards(1, false);
                    Console.WriteLine("{0}: {1}", player.Name, player.Cards);
                    nextStep = ContinuePlay(player);
                }

                //Sad imas nextStep, iliti razlog zasto smo ispali. Act accordingly. 

                //If stayed, continue

                //If Blackjack, then you win, continue.

                //If Busted, talk shit to him, continue

                //Zapamti kako je player prosao
            }

            //Ovde dealer igra, i sabiraju se scores svakog playera

            //Uporedi kako je ko prosao, i print

            //Za sada samo to odradi i zaboravi o lovi. Svaki igrac odigra po jednu partiju i to je to.

        }

        private NextMove ContinuePlay(Shark player)
        {


            var bjPlayer = player as BjPlayer;

            //ako se sjebo,
            return NextMove.Busted;

            //ako je blackjack,
            return NextMove.BlackJack;
            Console.Write("Hit (H) / Stay (S)?");

            var userResponse = Console.ReadLine();

            //ako je otkucao S,
            return NextMove.Stayed;

            //a ako nista od toga,
            return NextMove.KeepPlaying;
        }

        private enum NextMove
        {
            Stayed,
            BlackJack,
            Busted,
            KeepPlaying
        }



        private enum PLAYER_CHOICE
        {
            None,
            Hit,
            Stay
        }

        private void PrintPlayers()
        {
            foreach (var player in Players)
            {
                Console.WriteLine("{0}: {1}", player.Name, player.Cards);
            } 
        }
    }
}
