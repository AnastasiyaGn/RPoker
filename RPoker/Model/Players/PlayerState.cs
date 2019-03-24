using System;
using System.Collections.Generic;
using Model.Cards;
using ReactiveUI;

namespace Model.Players
{
	public class PlayerState : ReactiveObject
	{
		public PlayerState()
		{
		}

		#region Private fields

		private string _name;
		private bool _isDealer;
		private int _cash;
		private Card _firstCard;
		private Card _secondCard;

		#endregion

		#region Public properties

		public string Name
		{
			get { return _name; }
			set { this.RaiseAndSetIfChanged(ref _name, value, nameof(Name)); }
		}

		public bool IsDealer
		{
			get { return _isDealer; }
			set { this.RaiseAndSetIfChanged(ref _isDealer, value, nameof(IsDealer)); }
		}

		public int Cash
		{
			get { return _cash; }
			set { this.RaiseAndSetIfChanged(ref _cash, value, nameof(Cash)); }
		}

		public Card FirstCard
		{
			get { return _firstCard; }
			set { this.RaiseAndSetIfChanged(ref _firstCard, value, nameof(FirstCard)); }
		}

		public Card SecondCard
		{
			get { return _secondCard; }
			set { this.RaiseAndSetIfChanged(ref _secondCard, value, nameof(SecondCard)); }
		}

		private IEnumerable<Card> Cards => new List<Card>() {FirstCard, SecondCard};

		#endregion
	}
}
