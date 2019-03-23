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
			while (!_discardedCards.Contains(i))
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
			new Card(CardSuit.Club, CardRank.Two),
			new Card(CardSuit.Club, CardRank.Three),
			new Card(CardSuit.Club, CardRank.Four),
			new Card(CardSuit.Club, CardRank.Five),
			new Card(CardSuit.Club, CardRank.Six),
			new Card(CardSuit.Club, CardRank.Seven),
			new Card(CardSuit.Club, CardRank.Eight),
			new Card(CardSuit.Club, CardRank.Nine),
			new Card(CardSuit.Club, CardRank.Ten),
			new Card(CardSuit.Club, CardRank.Jack),
			new Card(CardSuit.Club, CardRank.Queen),
			new Card(CardSuit.Club, CardRank.King),
			new Card(CardSuit.Club, CardRank.Ace),

			new Card(CardSuit.Diamond, CardRank.Two),
			new Card(CardSuit.Diamond, CardRank.Three),
			new Card(CardSuit.Diamond, CardRank.Four),
			new Card(CardSuit.Diamond, CardRank.Five),
			new Card(CardSuit.Diamond, CardRank.Six),
			new Card(CardSuit.Diamond, CardRank.Seven),
			new Card(CardSuit.Diamond, CardRank.Eight),
			new Card(CardSuit.Diamond, CardRank.Nine),
			new Card(CardSuit.Diamond, CardRank.Ten),
			new Card(CardSuit.Diamond, CardRank.Jack),
			new Card(CardSuit.Diamond, CardRank.Queen),
			new Card(CardSuit.Diamond, CardRank.King),
			new Card(CardSuit.Diamond, CardRank.Ace),

			new Card(CardSuit.Spade, CardRank.Two),
			new Card(CardSuit.Spade, CardRank.Three),
			new Card(CardSuit.Spade, CardRank.Four),
			new Card(CardSuit.Spade, CardRank.Five),
			new Card(CardSuit.Spade, CardRank.Six),
			new Card(CardSuit.Spade, CardRank.Seven),
			new Card(CardSuit.Spade, CardRank.Eight),
			new Card(CardSuit.Spade, CardRank.Nine),
			new Card(CardSuit.Spade, CardRank.Ten),
			new Card(CardSuit.Spade, CardRank.Jack),
			new Card(CardSuit.Spade, CardRank.Queen),
			new Card(CardSuit.Spade, CardRank.King),
			new Card(CardSuit.Spade, CardRank.Ace),

			new Card(CardSuit.Hearth, CardRank.Two),
			new Card(CardSuit.Hearth, CardRank.Three),
			new Card(CardSuit.Hearth, CardRank.Four),
			new Card(CardSuit.Hearth, CardRank.Five),
			new Card(CardSuit.Hearth, CardRank.Six),
			new Card(CardSuit.Hearth, CardRank.Seven),
			new Card(CardSuit.Hearth, CardRank.Eight),
			new Card(CardSuit.Hearth, CardRank.Nine),
			new Card(CardSuit.Hearth, CardRank.Ten),
			new Card(CardSuit.Hearth, CardRank.Jack),
			new Card(CardSuit.Hearth, CardRank.Queen),
			new Card(CardSuit.Hearth, CardRank.King),
			new Card(CardSuit.Hearth, CardRank.Ace)
		};
		
		#endregion

	}
}
