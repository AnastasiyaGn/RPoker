using System.Collections.Generic;
using Model.Cards;

namespace ViewModel
{
	public interface ITableInfo
	{
		bool IsPreFlop { get; }
		bool IsFlop { get; }
		bool IsTurn { get; }
		bool IsRiver { get; }

		int CurrentBet { get; }
		int Pot { get; }
		int MinBet { get; }

		IEnumerable<Card> CardsOnTable { get; }
	}
}