using System;
using CardPhun.BlackJack;

namespace CardPhun
{
    internal static class Program
    {
        private static void Main()
        {
            var newGame = new BjGame(1, 100, "Dealer", "Stefan", "Pera", "Marko");
            var hasPlayers = true;
            while (hasPlayers)
            {
                newGame.Play();
                if (newGame.Players.Count == 0)
                {
                    hasPlayers = false;
                }
            }
        }
    }
}