using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Cards
{
	public enum CardSuit
	{
		Club,    // Крести
		Diamond, // Буби
		Hearth,  // Черви
		Spade    // Пики
	}

	public enum CardRank
	{
		Two = 2,
		Three = 3,
		Four = 4,
		Five = 5,
		Six = 6,
		Seven = 7,
		Eight = 8,
		Nine = 9,
		Ten = 10,
		Jack = 11, // Валет
		Queen = 12, // Дама
		King = 13, // Король
		Ace = 14  // Туз
	}

	public class Card
	{
		public Card(CardSuit suit, CardRank rank)
		{
			
		}

		public CardSuit Suit { get; set; }

		public CardRank Rank { get; set; }

		public bool IsHide { get; set; }



		public override string ToString()
		{
			return $"{RankMapper[Rank]}{SuitMapper[Suit]}";
		}


		public static Dictionary<CardRank, string> RankMapper = new Dictionary<CardRank, string>()
		{
			{ CardRank.Two,		"2" },
			{ CardRank.Three, "3" },
			{ CardRank.Four,	"4" },
			{ CardRank.Five,	"5" },
			{ CardRank.Six,		"6" },
			{ CardRank.Seven, "7" },
			{ CardRank.Eight, "8" },
			{ CardRank.Nine,	"9" },
			{ CardRank.Ten,		"10" },
			{ CardRank.Jack,	"J" },
			{ CardRank.Queen, "Q" },
			{ CardRank.King,	"K" },
			{ CardRank.Ace,		"A"},
		};

		public static Dictionary<CardSuit, string> SuitMapper = new Dictionary<CardSuit, string>()
		{
			{ CardSuit.Club,		"C" },
			{ CardSuit.Diamond, "D" },
			{ CardSuit.Hearth,	"H" },
			{ CardSuit.Spade,		"S" }
		};

	}
}
