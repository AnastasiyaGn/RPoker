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
			var playerCards = x.Item1;
			var tableCards = x.Item2;
		}

	}
}
