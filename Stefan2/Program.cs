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
             //Who is here? Players, descriptions and collection
             //What game are we playing?
             //Play the game

             //Second commit
          
        }
        
 /*       private static void Main1(string[] args)
        {

            var playerMoney = 100;
            while (true)

            {
                if (playerMoney <= 0)
                {
                    Console.WriteLine("You dont have enough money, come back later");
                    Console.ReadKey();
                    break;
                }
                
                Console.WriteLine("You have {0} $", playerMoney);
                Console.WriteLine("Place bet");
                var bet = Console.ReadLine();

                int pBet = int.Parse(bet);
               

                playerMoney = playerMoney - pBet;

                if (playerMoney < 0)
                {
                    Console.WriteLine("Thats cheating, come back when your serious about betting:)");
                    Console.ReadKey();
                    break;
                }

                Console.WriteLine("NEW GAME");
                var shuffledDeck = new CardDeck();
                var playerZbir = 0;
                var dealerZbir = 0;
                var n = "h";
                var playerHand = new CardSet();
                var dealerHand = new CardSet();
                for (int i = 0; i < 2; i++)
                {
                    playerHand.AddToSet(shuffledDeck.PopFromSet());
                    dealerHand.AddToSet(shuffledDeck.PopFromSet());
                }

                Console.WriteLine("Player hand: {0}", playerHand);
                Console.WriteLine("Dealer hand: {0}, HIDDEN", dealerHand.SeeCard(0));
                Console.WriteLine("Your total is {0}", BlackJackUtil.GetBlackjackSum(playerHand));
            
                while (playerZbir <= 21 & n == "h")
                {
                    Console.WriteLine("h to hit, s to stay");
                    n = Console.ReadLine();
                    if (n == "h")
                    {
                        playerHand.AddToSet(shuffledDeck.PopFromSet());
                        Console.WriteLine("Player hand: {0}", playerHand);
                        playerZbir = BlackJackUtil.GetBlackjackSum(playerHand);
                        Console.WriteLine("Your total is {0}", BlackJackUtil.GetBlackjackSum(playerHand));
                        if (playerZbir > 21)
                        {
                            Console.WriteLine("BUSTED\n");
                            break;
                        }

                        if (playerZbir == 21)
                        {
                            Console.WriteLine("BLACKJACK\n");
                            playerMoney = playerMoney + pBet * 2;
                            break;
                        }
                    }

                    if (n == "s")
                    {
                        playerZbir = BlackJackUtil.GetBlackjackSum(playerHand);
                        Console.WriteLine("Your total is {0}", playerZbir);
                    }
                }
                dealerZbir = BlackJackUtil.GetBlackjackSum(dealerHand);

                if (dealerZbir > playerZbir)
                {
                    Console.WriteLine("Delaer hand {0}", dealerHand);
                    Console.WriteLine("Dealer total is {0}, you LOSE\n", dealerZbir);
                }

                while (dealerZbir <= playerZbir && playerZbir < 21)
                {
                    if (dealerZbir == 21)
                    {
                        Console.WriteLine("Delaer hand {0}", dealerHand);
                        Console.WriteLine("Dealer BLACKJACK, you LOOSE\n");
                        break;
                    }
                    dealerHand.AddToSet(shuffledDeck.PopFromSet());

                    Console.WriteLine("Dealer hand: {0}", dealerHand);
                    dealerZbir = BlackJackUtil.GetBlackjackSum(dealerHand);
                    Console.WriteLine("Dealer total is {0}", dealerZbir);
                    if (dealerZbir == 21)
                    {
                        Console.WriteLine("Dealer BLACKJACK, you LOOSE\n");
                        break;
                    }
                    if (dealerZbir > 21)
                    {
                        Console.WriteLine("Dealer BUSTED, dealer total is {0}, you WIN\n", dealerZbir);
                        playerMoney = playerMoney + pBet * 2;

                        break;
                    }

                    if (dealerZbir > playerZbir && dealerZbir <= 21)
                    {
                        Console.WriteLine("Dealer total is {0}, you LOSE\n", dealerZbir);
                    }
                }

                if (playerZbir == dealerZbir)
                {
                    Console.WriteLine("You WIN");
                    playerMoney = playerMoney + pBet * 2;
                }
            }
        }*/
    }
}
