using System;
using CardPhun.BlackJack;

namespace CardPhun
{
    internal static class Program
    {
        private static void Main()
        {
            var newGame = new BjGame(1, 100, "Dealer", "Stefan", "Pera", "Marko");
            var hasBalance = true;
            while (hasBalance)
            {
                newGame.Play();
                if (newGame.Players.Count == 0)
                {
                    hasBalance = false;
                }
            }
        }
    }
}