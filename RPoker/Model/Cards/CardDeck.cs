using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Cards
{
	public class CardDeck
	{
		#region Ctor

		public CardDeck()
		{
			_cards = new List<Card>(AllDeck);
			_generator = new Random();
			_discardedCards = new List<int>();
			Shuffle();
			BuildMap();
		}

		#endregion

		#region Private methods

		private List<int> _discardedCards;
		private List<Card> _cards;
		private Dictionary<(CardRank, CardSuit), int> _cardsPos;
		private Random _generator;

		#endregion

		#region Public properties

		public IEnumerable<Card> Cards => _cards;

		public int RemainingCards => _cards.Count - _discardedCards.Count;

		#endregion

		#region Public methods

		public Card GetRandomCard()
		{
			int i = _generator.Next(_cards.Count);
			while (_discardedCards.Contains(i))
				i = _generator.Next(_cards.Count);

			_discardedCards.Add(i);
			return _cards[i];
		}

		public Card this[CardRank rank, CardSuit suit]
		{
			get { return _cards[_cardsPos[(rank, suit)]]; }
		}

		#endregion

		#region Private methods

		private void Shuffle()
		{
			int n = _cards.Count;
			while (n > 1)
			{
				n--;
				int k = _generator.Next(n + 1);
				Card value = _cards[k];
				_cards[k] = _cards[n];
				_cards[n] = value;
			}
		}

		private void BuildMap()
		{
			_cardsPos = new Dictionary<(CardRank, CardSuit), int>();
			for(int i = 0; i < _cards.Count; ++i)
				_cardsPos.Add((_cards[i].Rank, _cards[i].Suit), i);
		}

		#endregion

		#region Static members

		public static List<Card> AllDeck = new List<Card>()
		{
			new Card(CardSuit.Club, CardRank.Two) { IsHide = true },
			new Card(CardSuit.Club, CardRank.Three) { IsHide = true },
			new Card(CardSuit.Club, CardRank.Four) { IsHide = true },
			new Card(CardSuit.Club, CardRank.Five) { IsHide = true },
			new Card(CardSuit.Club, CardRank.Six) { IsHide = true },
			new Card(CardSuit.Club, CardRank.Seven) { IsHide = true },
			new Card(CardSuit.Club, CardRank.Eight) { IsHide = true },
			new Card(CardSuit.Club, CardRank.Nine) { IsHide = true },
			new Card(CardSuit.Club, CardRank.Ten) { IsHide = true },
			new Card(CardSuit.Club, CardRank.Jack) { IsHide = true },
			new Card(CardSuit.Club, CardRank.Queen) { IsHide = true },
			new Card(CardSuit.Club, CardRank.King) { IsHide = true },
			new Card(CardSuit.Club, CardRank.Ace) { IsHide = true },

			new Card(CardSuit.Diamond, CardRank.Two) { IsHide = true },
			new Card(CardSuit.Diamond, CardRank.Three) { IsHide = true },
			new Card(CardSuit.Diamond, CardRank.Four) { IsHide = true },
			new Card(CardSuit.Diamond, CardRank.Five) { IsHide = true },
			new Card(CardSuit.Diamond, CardRank.Six) { IsHide = true },
			new Card(CardSuit.Diamond, CardRank.Seven) { IsHide = true },
			new Card(CardSuit.Diamond, CardRank.Eight) { IsHide = true },
			new Card(CardSuit.Diamond, CardRank.Nine) { IsHide = true },
			new Card(CardSuit.Diamond, CardRank.Ten) { IsHide = true },
			new Card(CardSuit.Diamond, CardRank.Jack) { IsHide = true },
			new Card(CardSuit.Diamond, CardRank.Queen) { IsHide = true },
			new Card(CardSuit.Diamond, CardRank.King) { IsHide = true },
			new Card(CardSuit.Diamond, CardRank.Ace) { IsHide = true },

			new Card(CardSuit.Spade, CardRank.Two) { IsHide = true },
			new Card(CardSuit.Spade, CardRank.Three) { IsHide = true },
			new Card(CardSuit.Spade, CardRank.Four) { IsHide = true },
			new Card(CardSuit.Spade, CardRank.Five) { IsHide = true },
			new Card(CardSuit.Spade, CardRank.Six) { IsHide = true },
			new Card(CardSuit.Spade, CardRank.Seven) { IsHide = true },
			new Card(CardSuit.Spade, CardRank.Eight) { IsHide = true },
			new Card(CardSuit.Spade, CardRank.Nine) { IsHide = true },
			new Card(CardSuit.Spade, CardRank.Ten) { IsHide = true },
			new Card(CardSuit.Spade, CardRank.Jack) { IsHide = true },
			new Card(CardSuit.Spade, CardRank.Queen) { IsHide = true },
			new Card(CardSuit.Spade, CardRank.King) { IsHide = true },
			new Card(CardSuit.Spade, CardRank.Ace) { IsHide = true },

			new Card(CardSuit.Hearth, CardRank.Two) { IsHide = true },
			new Card(CardSuit.Hearth, CardRank.Three) { IsHide = true },
			new Card(CardSuit.Hearth, CardRank.Four) { IsHide = true },
			new Card(CardSuit.Hearth, CardRank.Five) { IsHide = true },
			new Card(CardSuit.Hearth, CardRank.Six) { IsHide = true },
			new Card(CardSuit.Hearth, CardRank.Seven) { IsHide = true },
			new Card(CardSuit.Hearth, CardRank.Eight) { IsHide = true },
			new Card(CardSuit.Hearth, CardRank.Nine) { IsHide = true },
			new Card(CardSuit.Hearth, CardRank.Ten) { IsHide = true },
			new Card(CardSuit.Hearth, CardRank.Jack) { IsHide = true },
			new Card(CardSuit.Hearth, CardRank.Queen) { IsHide = true },
			new Card(CardSuit.Hearth, CardRank.King) { IsHide = true },
			new Card(CardSuit.Hearth, CardRank.Ace) { IsHide = true }
		};
		
		#endregion

	}
}
