using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Model.Cards
{
	public class CombinationComparer : IComparer<IEnumerable<Card>>
	{
		public int Compare(IEnumerable<Card> x, IEnumerable<Card> y)
		{
            var xComb = CombinationChecker.DetermineCombination(x);
            var yComb = CombinationChecker.DetermineCombination(y);
            if (xComb != yComb)
                return (int) xComb - (int) yComb;

            var xList = x.ToList();
            var yList = y.ToList();
            CardComparer comparator = new CardComparer();
            xList.Sort(comparator);
            yList.Sort(comparator);

            return comparator.Compare(xList[0], yList[0]);
        }

	}
}
