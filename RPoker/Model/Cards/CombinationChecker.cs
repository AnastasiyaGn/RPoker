using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Cards
{

	public enum Combination
	{
		HighCard = 1,
		Pair = 2,
		TwoPair = 3,
		ThreeOfKind = 4,
		Straight = 5,
    Flush = 6,
		FullHouse = 7,
		Kape = 8,
		StraightFlush = 9,
		RoyalFlush = 10
	};

	public static class CombinationChecker
	{
		public static bool IsRoyalFlush(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			return false;
		}

		public static bool IsStraightFlush(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			return false;
		}

		public static bool IsKape(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			return false;
		}

		public static bool IsFullHouse(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			return false;
		}

		public static bool IsFlush(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			return false;
		}

		public static bool IsStraight(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			return false;
		}

		public static bool IsThreeOfKind(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			return false;
		}

		public static bool IsTwoPair(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			return false;
		}

		public static bool IsPair(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			return false;
		}

		public static bool IsHightCard(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			return false;
		}

		public static Combination DetermineCombination(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			return Combination.FullHouse;
		}

	}
}
