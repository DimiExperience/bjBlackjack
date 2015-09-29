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
        public BjGame(int numberOdDecks, int initBalance, string dealerName,  params string[] playerNames)
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
                while (nextStep == NextMove.KeepPlaying)
                {
                    DealCards(1, false);
                    Console.WriteLine("{0}: {1}", player.Name, player.Cards);
                    nextStep = ContinuePlay(player);
                }

                if (nextStep == NextMove.Busted)
                {
                    Console.WriteLine("You are busted");
                }
                if (nextStep == NextMove.BlackJack)
                {
                    Console.WriteLine("BLACKJACK");
                    //da li ovde da dodamo balans i da ga zanemarimo posle, tj da sve sto se tice para odradimo ovde, a samo poredjenje posle
                }
                if (nextStep == NextMove.Stayed)
                {
                    Console.WriteLine("STAYED");
                    
                    if (player.Cards.GetSumOfCards() >= 17)
                    {
                        Console.WriteLine("Wise decision, STAYED");
                    }

                }



                // string decision = playerChoice; ovo ocigledno ne radi, kako? (dobra ideja, onda samo ako je stayed uporedjujemo sa dilerom
                // sta god drugo da je, nema potrebe

                decision = nextStep.ToString(); // ali ovo ce mozda da radi, sada imamo string, pa ga posle proveravamo, right?
                // BTW onaj gore PLAYER_CHOICE, sta ce nam to, mislim da ovo menja to sto smo hteli da radimo



                ////Sad imas nextStep, iliti razlog zasto smo ispali. Act accordingly.

                ////If stayed, continue

                ////If Blackjack, then you win, continue.

                ////If Busted, talk shit to him, continue


                //Zapamti kako je player prosao > NE ZNAM KAKO.....(TJ. NE ZNAM NA STA MISLIS, 
                //ZAR NIJE VEC ZAPAMTIO? mozda da mu dodamo string-decision u BjPlayer, pa tu da pamti string)

                //Sustinski, pravilo jeste da dealer hituje dok ne dobije 17, onda ide stay, tako da cu tako probati da odradim,
                //pa onda da poredimo, ali ona moja verzija je zanimljivija sto se tice pravljenja:) jedino sto ne moze da se iskoristi kasnije

                //I DA, postoji pravilo da ako si dobio 2 cards BlackJack, onda je push, i sigurno si ili dobio pare ili dobio nazad bet

                //nesto sam zeznuo, ne radi vise, to moras da pogledas, a sada cu da probam na pamet da odradim jos koju stvar
                


                

                //i sada compare, ali mi treba pomoc, pa cu ostaviti ovo kada dodjem kod tebe


            }

            Console.WriteLine("Dealer cards {0}", dealersCards);

            while (dealersCards.GetSumOfCards() < 17 && dealersCards.GetSumOfCards() > 0)  //ovde treba mozda napraviti da se izvrsava samo ako je player stayed ili BlackJack
            {
                DealCardsDealer(true);
                Console.WriteLine("Dealer cards {0}", dealersCards);
            }


            if (dealersCards.GetSumOfCards() == 21)

            {
                Console.WriteLine("Dealer BLACKJACK, dealer WINS");
            }

            foreach (var player in Players)
            {
                if (decision == "Stayed")
                {
                    if (player.Cards.GetSumOfCards() > dealersCards.GetSumOfCards())
                    {
                        Console.WriteLine("Player {0} WINS", player.Name);
                        //verovatno ovde dodajemo balans
                    }
                    else
                    {
                        Console.WriteLine("Dealer WINS");
                    }

                }

                //inace, nekada radi nekada ne radi ovaj metod sto skracuje keceve na 1 ako je vise od 21...

                //i da, jako bitno, ne radi 14=>10(ne skracuje kraljeve, dame i zandare)



            }


            //Ovde dealer igra, i sabiraju se scores svakog playera

            //Uporedi kako je ko prosao, i print

            //Za sada samo to odradi i zaboravi o lovi. Svaki igrac odigra po jednu partiju i to je to.

            

        }

        private NextMove ContinuePlay(Shark player)
        {


            var bjPlayer = player as BjPlayer;

            if (player.Cards.GetSumOfCards() >21)
            {
                return NextMove.Busted;
            }


            if (player.Cards.GetSumOfCards() == 21)
            {
                return NextMove.BlackJack;
            }
            
            Console.Write("Hit (H) / Stay (S)?");

            var userResponse = Console.ReadLine();

            

            if (String.Compare(userResponse, "s", true) == 0)
            {
                return NextMove.Stayed;
            }
            

            
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

        public string decision { get; set; }
    }
}
