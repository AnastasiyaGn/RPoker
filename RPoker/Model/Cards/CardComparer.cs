using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Cards
{
	public class CardComparer : IComparer<Card>
	{
		public int Compare(Card x, Card y)
		{
			return (int)x.Rank - (int)y.Rank;
		}
	}
}
