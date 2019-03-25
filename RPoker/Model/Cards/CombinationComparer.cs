using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Model.Cards
{
	public class CombinationComparer : IComparer<(IEnumerable<Card>, IEnumerable<Card>)>
	{
		public int Compare((IEnumerable<Card>, IEnumerable<Card>) x, (IEnumerable<Card>, IEnumerable<Card>) y)
		{
			var handXCards = x.Item1;
			var handYCards = y.Item1;
			var tableCards = x.Item2;
		
			Combination xComb = CombinationChecker.DetermineCombination(handXCards, tableCards);
			Combination yComb = CombinationChecker.DetermineCombination(handYCards, tableCards);

			if (xComb != yComb)
				return (int)xComb - (int)yComb;


			switch (xComb)
			{
				case Combination.StraightFlush:
					return CompareStraightFlush(handXCards, handYCards, tableCards);

				case Combination.FourOfKind:
					return CompareFourOfKind(handXCards, handYCards, tableCards);

				case Combination.FullHouse:
					return CompareFullHouse(handXCards, handYCards, tableCards);

				case Combination.Flush:
					return CompareFlush(handXCards, handYCards, tableCards);

				case Combination.Straight:
					return CompareStraight(handXCards, handYCards, tableCards);

				case Combination.ThreeOfKind:
					return CompareThreeOfKind(handXCards, handYCards, tableCards);

				case Combination.TwoPair:
					return CompareTwoPair(handXCards, handYCards, tableCards);

				case Combination.Pair:
					return ComparePair(handXCards, handYCards, tableCards);

				case Combination.HighCard:
					return CompareHighCard(handXCards, handYCards);
			}

			return -1000;
		}


		public int CompareStraightFlush(IEnumerable<Card> x, IEnumerable<Card> y, IEnumerable<Card> table)
		{
			var xAll = new List<Card>(x);
			xAll.AddRange(table);
			var yAll = new List<Card>(y);
			yAll.AddRange(table);

			var sfX = ExtractStraightFlush(xAll).ToList();
			var sfY = ExtractStraightFlush(yAll).ToList();

			var comp = new CardComparer();

			return comp.Compare(sfX.Last(), sfY.Last());
		}

		public int CompareFourOfKind(IEnumerable<Card> x, IEnumerable<Card> y, IEnumerable<Card> table)
		{
			return 0;
		}

		public int CompareFullHouse(IEnumerable<Card> x, IEnumerable<Card> y, IEnumerable<Card> table)
		{
			return 0;
		}

		public int CompareFlush(IEnumerable<Card> x, IEnumerable<Card> y, IEnumerable<Card> table)
		{
			var pair = CombinationChecker.MaxSuitCount(table);
			var xTable = table.Where(p => p.Suit == pair.Item1).ToList();

			var xHand = x.Where(p => p.Suit == pair.Item1).ToList();
			var yHand = y.Where(p => p.Suit == pair.Item1).ToList();
			if (xHand.Count == 0 && yHand.Count == 0)
				return 0;

			if (xHand.Count == 0 && yHand.Count != 0)
				return -1;

			if (xHand.Count != 0 && yHand.Count == 0)
				return 1;

			var comp = new CardComparer();
			xHand.Sort(comp);
			yHand.Sort(comp);

			return comp.Compare(xHand.Last(), yHand.Last());
		}

		public int CompareStraight(IEnumerable<Card> x, IEnumerable<Card> y, IEnumerable<Card> table)
		{
			return 0;
		}

		public int CompareThreeOfKind(IEnumerable<Card> x, IEnumerable<Card> y, IEnumerable<Card> table)
		{
			return 0;
		}

		private int CompareTwoPair(IEnumerable<Card> x, IEnumerable<Card> y, IEnumerable<Card> table)
		{
			return 0;
		}

		public int ComparePair(IEnumerable<Card> x, IEnumerable<Card> y, IEnumerable<Card> table)
		{
			return 0;
		}

		public int CompareHighCard(IEnumerable<Card> playerXCards, IEnumerable<Card> playerYCards)
		{
			var cardsX = new List<Card>(playerXCards);
			var cardsY = new List<Card>(playerYCards);

			CardComparer comparator = new CardComparer();
			cardsX.Sort(comparator);
			cardsY.Sort(comparator);

			return comparator.Compare(cardsX.Last(), cardsY.Last());
		}


		public IEnumerable<Card> ExtractStraightFlush(IEnumerable<Card> x)
		{
			var pair = CombinationChecker.MaxSuitCount(x);
			var maxSuit = pair.Item1;

			var list = x.Where(p => p.Suit == maxSuit).ToList();

			bool haveAce = list.Count(p => p.Rank == CardRank.Ace && p.Suit == maxSuit) == 1;
			bool haveTwo = list.Count(p => p.Rank == CardRank.Two && p.Suit == maxSuit) == 1;
			if (haveAce && haveTwo)
			{
				var outList = new List<Card>();
				outList.Add(list.Find(p => p.Rank == CardRank.Ace));
				outList.Add(list.Find(p => p.Rank == CardRank.Two));
				outList.Add(list.Find(p => p.Rank == CardRank.Three));
				outList.Add(list.Find(p => p.Rank == CardRank.Four));
				outList.Add(list.Find(p => p.Rank == CardRank.Five));

				return outList;
			}

			var forDel = new List<Card>();
			var comp = new CardComparer();
			list.Sort(comp);

			for (int i = 0; i < list.Count - 1 && comp.Compare(list[i], list[i + 1]) != -1; ++i)
				forDel.Add(list[i]);

			list.RemoveAll(p => forDel.Contains(p));
			list.Sort(comp);
			forDel.Clear();

			for (int i = list.Count - 1; i > 0 && comp.Compare(list[i], list[i - 1]) != 1; --i)
				forDel.Add(list[i]);

			list.RemoveAll(p => forDel.Contains(p));
			list.Sort(comp);

			return list;
		}

	}
}
