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


			return 0;
		}
	}
}
