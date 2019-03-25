using System;
using System.Collections.Generic;
using System.Linq;
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
			var cards = new List<Card>(tableCards);
			cards.AddRange(playerCards);

			var comparer = new CardComparer();
			cards.Sort(comparer);

			int spadeCount = cards.Count(x => x.Suit == CardSuit.Spade);
			int hearthCount = cards.Count(x => x.Suit == CardSuit.Hearth);
			int diamondCount = cards.Count(x => x.Suit == CardSuit.Diamond);
			int clubCount = cards.Count(x => x.Suit == CardSuit.Club);

			if (spadeCount != 5 || hearthCount != 5 || diamondCount != 5 || clubCount != 5)
				return false;

			if
			(
				cards[cards.Count - 1].Rank == CardRank.Ace &&
				cards[cards.Count - 2].Rank == CardRank.King &&
				cards[cards.Count - 3].Rank == CardRank.Queen &&
				cards[cards.Count - 4].Rank == CardRank.Jack &&
				cards[cards.Count - 5].Rank == CardRank.Ten
			)
				return true;


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
			var cards = new List<Card>(tableCards);
			cards.AddRange(playerCards);

			var comparer = new CardComparer();
			cards.Sort(comparer);

			int spadeCount = cards.Count(x => x.Suit == CardSuit.Spade);
			int hearthCount = cards.Count(x => x.Suit == CardSuit.Hearth);
			int diamondCount = cards.Count(x => x.Suit == CardSuit.Diamond);
			int clubCount = cards.Count(x => x.Suit == CardSuit.Club);

			if (spadeCount >= 5 || hearthCount >= 5 || diamondCount >= 5 || clubCount >= 5)
				return true;

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
