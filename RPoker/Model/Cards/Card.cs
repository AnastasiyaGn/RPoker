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

		private CardSuit Suit { get; set; }

		private CardRank Rank { get; set; }


		public override string ToString()
		{
			return "Карта";
		}

	}
}
