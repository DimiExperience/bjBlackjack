using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toore.Shuffling;

namespace CardPhun
{
    public class CardSet
    {
        protected List<Card> _mCards;
        public void AddToSet(Card card)
        {
            if (_mCards == null)
            {
                _mCards = new List<Card>();
            }
            _mCards.Add(card);
        }

        public Card SeeCard(int index)
        {
            return _mCards[index];
        }

        public void Shuffle()
        {
            var s = new FisherYatesShuffle(new RandomWrapper());
            _mCards = s.Shuffle(_mCards).ToList();
        }

        public int Count
        {
            get
            {
                return _mCards == null ? 0 : _mCards.Count;
            }
        }

        public Card PopFromSet(bool first = false)
        {
            if (_mCards == null || _mCards.Count == 0)
            {
                throw new InvalidOperationException("No cards to pop.");
            }
            var retVal = first ? _mCards.First() : _mCards.Last();
            if (first)
            {
                _mCards.RemoveAt(0);
            }
            else
            {
                _mCards.RemoveAt(_mCards.Count - 1);
            }

            return retVal;
        }

        public void AddSet(CardSet set)
        {
            _mCards.AddRange(set._mCards);
        }

        public virtual int GetSumOfCards()
        {
            return _mCards == null ? 0 : _mCards.Sum(c => c.Number); //Procitaj ili pluralsight: LINQ, Lambda Expressions

            //Ekvivalent:
            //var sum = 0;
            //foreach (var c in _mCards)
            //{
            //    sum += c.Number;
            //}
        }

        public List<Card> GetCardList()
        {
            return _mCards;
        } 

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var card in _mCards)
            {
                sb.AppendFormat("{0}, ", card);
            }
            return sb.ToString().TrimEnd(',');
        }

    }
}
