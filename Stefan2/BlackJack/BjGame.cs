using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack;
using CardPhun.Game;
using Player;

namespace Stefan2.BlackJack
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


        }
    }
}
