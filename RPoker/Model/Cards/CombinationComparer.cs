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
			var playerXCards = x.Item1;
			var tableXCards = x.Item2;
			var playerYCards = y.Item1;
			var tableYCards = y.Item2;
		
			Combination xComb = CombinationChecker.DetermineCombination(playerXCards, tableXCards);
			Combination yComb = CombinationChecker.DetermineCombination(playerYCards, tableYCards);

			if (xComb != yComb)
				return (int)xComb - (int)yComb;

			if (xComb == Combination.RoyalFlush)
				return 0;
			
			if (xComb == yComb)
			{
				switch (xComb)
				{
					case Combination.RoyalFlush:
						return CompareHighCard(playerXCards, playerYCards);

					case Combination.StraightFlush:
						return CompareStraightFlush(playerXCards, tableXCards, playerYCards, tableYCards);
				}					
			}

			return 0;
		}


		private int CompareStraightFlush(IEnumerable<Card> playerXCards, IEnumerable<Card> tableXCards, IEnumerable<Card> playerYCards, IEnumerable<Card> tableYCards)
		{
			var cardsX = new List<Card>(tableXCards);
			cardsX.AddRange(playerXCards);
			var cardsY = new List<Card>(tableYCards);
			cardsY.AddRange(playerYCards);

			var pair = MaxSuitCount(cardsX);

			cardsX = cardsX.Where(x => x.Suit == pair.Item1).ToList();
			cardsY = cardsY.Where(x => x.Suit == pair.Item1).ToList();

			CardComparer comparator = new CardComparer();
			cardsX.Sort(comparator);
			cardsY.Sort(comparator);

			return comparator.Compare(cardsX.Last(), cardsY.Last());
		}

		private int CompareKape(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			return 0;
		}

		private int CompareFullHouse(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			return 0;
		}

		private int CompareFlush(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			return 0;
		}

		private int CompareStraight(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			return 0;
		}

		private int CompareThreeOfKind(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			return 0;
		}

		private int CompareTwoPair(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			return 0;
		}

		private int ComparePair(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			return 0;
		}

		private int CompareHighCard(IEnumerable<Card> playerXCards, IEnumerable<Card> playerYCards)
		{
			var cardsX = new List<Card>(playerXCards);
			var cardsY = new List<Card>(playerYCards);

			CardComparer comparator = new CardComparer();
			cardsX.Sort(comparator);
			cardsY.Sort(comparator);

			return comparator.Compare(cardsX.Last(), cardsY.Last());
		}

		public static (CardSuit, int) MaxSuitCount(IEnumerable<Card> cards)
		{
			int hC = cards.Count(x => x.Suit == CardSuit.Hearth);
			int sC = cards.Count(x => x.Suit == CardSuit.Spade);
			int dC = cards.Count(x => x.Suit == CardSuit.Diamond);
			int cC = cards.Count(x => x.Suit == CardSuit.Club);

			CardSuit maxSuit = CardSuit.Hearth;
			int max = hC;

			if (sC > max)
			{
				maxSuit = CardSuit.Spade;
				max = sC;
			}

			if (dC > max)
			{
				maxSuit = CardSuit.Diamond;
				max = dC;
			}

			if (cC > max)
			{
				maxSuit = CardSuit.Club;
				max = cC;
			}

			return (maxSuit, max);
		}
	}
}
