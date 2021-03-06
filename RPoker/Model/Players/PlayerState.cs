﻿using System;
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
		private bool _isSmallBlind;
		private bool _isBigBlind;
		private int _cash;
		private Card _firstCard;
		private Card _secondCard;
		private int _number;

		#endregion

		#region Public properties

		public int Number
		{
			get { return _number; }
			set { this.RaiseAndSetIfChanged(ref _number, value, nameof(Number)); }
		}

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

		public bool IsSmallBlind
		{
			get { return _isSmallBlind; }
			set { this.RaiseAndSetIfChanged(ref _isSmallBlind, value, nameof(IsSmallBlind)); }
		}

		public bool IsBigBlind
		{
			get { return _isBigBlind; }
			set { this.RaiseAndSetIfChanged(ref _isBigBlind, value, nameof(IsBigBlind)); }
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
