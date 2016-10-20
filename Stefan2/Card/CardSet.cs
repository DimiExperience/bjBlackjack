using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toore.Shuffling;

namespace CardPhun.Card
{
    public abstract class CardSet<T> where T : Card
    {
        protected List<T> MCards;

        public int Count => MCards?.Count ?? 0;

        public void AddToSet(T card)
        {
            if (MCards == null)
                MCards = new List<T>();
            MCards.Add(card);
        }

        public T SeeCard(int index)
        {
            return MCards[index];
        }

        public void Shuffle()
        {
            var s = new FisherYatesShuffle(new RandomWrapper());
            MCards = s.Shuffle(MCards).ToList();
        }


        public T PopFromSet(bool first = false)
        {
            if ((MCards == null) || (MCards.Count == 0))
                throw new InvalidOperationException("No cards to pop.");
            var retVal = first ? MCards.First() : MCards.Last();
            if (first)
                MCards.RemoveAt(0);
            else
                MCards.RemoveAt(MCards.Count - 1);

            return retVal;
        }

        public void AddSet(CardSet<T> set)
        {
            if (MCards == null)
                MCards = new List<T>();
            MCards.AddRange(set.MCards);
        }


        public List<T> GetCardList()
        {
            return MCards;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var card in MCards)
                sb.AppendFormat("{0}, ", card);
            return sb.ToString().TrimEnd(',');
        }
    }
}