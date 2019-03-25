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

			var pair = MaxSuitCount(cards);

			if (pair.Item2 < 5) return false;

			cards = cards.Where(x => x.Suit == pair.Item1).ToList();

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
			var cards = new List<Card>(tableCards);
			cards.AddRange(playerCards);

			var comparer = new CardComparer();
			cards.Sort(comparer);

			var pair = MaxSuitCount(cards);
			CardSuit maxSuit = pair.Item1;
			int max = pair.Item2;

			if (max < 5) return false;

			bool haveAce = cards.Count(x => x.Rank == CardRank.Ace && x.Suit == maxSuit) == 1;
			bool haveTwo = cards.Count(x => x.Rank == CardRank.Two && x.Suit == maxSuit) == 1;

			if (haveTwo && haveAce)
			{
				if 
				(
					cards.Exists(x => x.Rank == CardRank.Three && x.Suit == maxSuit) &&
					cards.Exists(x => x.Rank == CardRank.Four && x.Suit == maxSuit) &&
					cards.Exists(x => x.Rank == CardRank.Five && x.Suit == maxSuit)
				) return true;
			}

			for (int i = 0; i < cards.Count - 5; ++i)
			{
				bool isSequence = true;
				for (int j = 0; j < 4 && isSequence; ++j)
				{
					isSequence = comparer.Compare(cards[i + j], cards[i + j + 1]) == -1;
				}

				if (isSequence) return true;
			}

			return false;
		}

		public static bool IsKape(IEnumerable<Card> playerCards, IEnumerable<Card> tableCards)
		{
			var cards = new List<Card>(tableCards);
			cards.AddRange(playerCards);

			var cardDict = CountCards(cards);

			foreach(var i in cardDict)
				if (i.Value == 4)
					return true;

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

			var pair = MaxSuitCount(cards);
			if (pair.Item2 >= 5)
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


		public static Dictionary<CardRank, int> CountCards(IEnumerable<Card> cards)
		{
			var cardDict = new Dictionary<CardRank, int>();
			foreach (var i in cards)
			{
				if (cardDict.ContainsKey(i.Rank))
					cardDict[i.Rank] = cardDict[i.Rank] + 1;
				else
					cardDict.Add(i.Rank, 1);
			}

			return cardDict;
		}

	}
}
