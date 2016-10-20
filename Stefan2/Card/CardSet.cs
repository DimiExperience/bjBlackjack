using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toore.Shuffling;

namespace CardPhun
{
    public abstract class CardSet<T> where T : Card
    {
        protected List<T> _mCards;
        public void AddToSet(T card)
        {
            if (_mCards == null)
            {
                _mCards = new List<T>();
            }
            _mCards.Add(card);
        }

        public T SeeCard(int index)
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

        
        public T PopFromSet(bool first = false)
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

        public void AddSet(CardSet<T> set)
        {
            if (_mCards == null)
            {
                _mCards = new List<T>();
            }
            _mCards.AddRange(set._mCards);
        }

        public abstract int GetSumOfCards();
/*        {
            return _mCards == null ? 0 : _mCards.Sum(c => c.Value); //Procitaj ili pluralsight: LINQ, Lambda Expressions
        }*/

        public List<T> GetCardList()
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
