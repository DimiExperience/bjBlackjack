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
            while (playerChoice != PLAYER_CHOICE.Stay)
            {
                Console.ReadLine(); //TODO!!!


                //Ucitaj sve

             }

            //Na kraju bi trebalo da imas player.Cards sto ako trazis GetSumOfCards() ce ti dati -1 ili neki pozitivan broj.


            // Onda isto uradi i za dilera samo sa njegovim pravilima

            //I, to je potez. Posle cemo o lovi.

        }

        private enum PLAYER_CHOICE
        {
            None,
            Hit,
            Stay
        }
    }
}
