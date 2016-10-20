using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player;

namespace BlackJack
{
    using Toore.Shuffling;

    class Program
    {
        private static void Main(string[] args)
        {
            BjGame newGame = new BjGame(1, 100, "Dealer", "Stefan", "Pera", "Marko");
            var hasBalance = true;
            while (hasBalance)
            {
                newGame.Play();
                foreach (var player in newGame.Players)
                {
                    hasBalance = player.Balance > 0;
                }
            }
        }
    }
}
