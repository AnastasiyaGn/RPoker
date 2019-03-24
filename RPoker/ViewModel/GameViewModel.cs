using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Model.Players;
using ReactiveUI;
using Model.Cards;

namespace ViewModel
{
	public class GameViewModel : ReactiveObject
	{
		public GameViewModel()
		{
			InitializeObject();
		}

		#region Private fields

		private List<PlayerViewModel> _players;
		private int _pot;
		private int _minBet;
		private int _startCash;
		private CardDeck _deck;
		private Card _flopCard1;
		private Card _flopCard2;
		private Card _flopCard3;
		private Card _turnCard;
		private Card _riverCard;

		#endregion

		#region Public properties

		public int Pot
		{
			get { return _pot; }
			set { this.RaiseAndSetIfChanged(ref _pot, value, nameof(Pot)); }
		}

		public int MinBet
		{
			get { return _minBet; }
			set { this.RaiseAndSetIfChanged(ref _minBet, value, nameof(MinBet)); }
		}

		public int StartCash
		{
			get { return _startCash; }
			set { this.RaiseAndSetIfChanged(ref _startCash, value, nameof(StartCash)); }
		}

		public PlayerViewModel FirstPlayer { get; private set; }
		public PlayerViewModel SecondPlayer { get; private set; }
		public PlayerViewModel ThirdPlayer { get; private set; }
		public PlayerViewModel FourthPlayer { get; private set; }
		public PlayerViewModel FifthPlayer { get; private set; }
		public PlayerViewModel SixthPlayer { get; private set; }

		public Card FlopCard1
		{
			get { return _flopCard1; }
			set { this.RaiseAndSetIfChanged(ref _flopCard1, value, nameof(FlopCard1)); }
		}

		public Card FlopCard2
		{
			get { return _flopCard2; }
			set { this.RaiseAndSetIfChanged(ref _flopCard2, value, nameof(FlopCard2)); }
		}

		public Card FlopCard3
		{
			get { return _flopCard3; }
			set { this.RaiseAndSetIfChanged(ref _flopCard3, value, nameof(FlopCard3)); }
		}

		public Card TurnCard
		{
			get { return _turnCard; }
			set { this.RaiseAndSetIfChanged(ref _turnCard, value, nameof(TurnCard)); }
		}

		public Card RiverCard
		{
			get { return _riverCard; }
			set { this.RaiseAndSetIfChanged(ref _riverCard, value, nameof(RiverCard)); }
		}


		#endregion

		#region Public methods

		public void DealCards()
		{
			FirstPlayer.PlayerState.FirstCard = _deck.GetRandomCard();
			FirstPlayer.PlayerState.SecondCard = _deck.GetRandomCard();
			FirstPlayer.PlayerState.FirstCard.IsHide = false;
			FirstPlayer.PlayerState.SecondCard.IsHide = false;

			SecondPlayer.PlayerState.FirstCard = _deck.GetRandomCard();
			SecondPlayer.PlayerState.SecondCard = _deck.GetRandomCard();

			ThirdPlayer.PlayerState.FirstCard = _deck.GetRandomCard();
			ThirdPlayer.PlayerState.SecondCard = _deck.GetRandomCard();

			FourthPlayer.PlayerState.FirstCard = _deck.GetRandomCard();
			FourthPlayer.PlayerState.SecondCard = _deck.GetRandomCard();

			FifthPlayer.PlayerState.FirstCard = _deck.GetRandomCard();
			FifthPlayer.PlayerState.SecondCard = _deck.GetRandomCard();

			SixthPlayer.PlayerState.FirstCard = _deck.GetRandomCard();
			SixthPlayer.PlayerState.SecondCard = _deck.GetRandomCard();
		}

		public void MakeFlop()
		{
			FlopCard1 = _deck.GetRandomCard();
			FlopCard2 = _deck.GetRandomCard();
			FlopCard3 = _deck.GetRandomCard();
		}

		#endregion

		#region Private methods

		private void InitializeObject()
		{
			Pot = 0;
			MinBet = 50;
			StartCash = 10000;
			_players = new List<PlayerViewModel>();

			FirstPlayer = new PlayerViewModel()
				{ PlayerState = new PlayerState() { Cash = StartCash, IsDealer = true, Name = "Игрок" } };
			SecondPlayer = new PlayerViewModel()
				{ PlayerState = new PlayerState() { Cash = StartCash, IsDealer = false, Name = "Компьютер 1" } };
			ThirdPlayer = new PlayerViewModel()
				{ PlayerState = new PlayerState() { Cash = StartCash, IsDealer = false, Name = "Компьютер 2" } };
			FourthPlayer = new PlayerViewModel()
				{ PlayerState = new PlayerState() { Cash = StartCash, IsDealer = false, Name = "Компьютер 3" } };
			FifthPlayer = new PlayerViewModel()
				{ PlayerState = new PlayerState() { Cash = StartCash, IsDealer = false, Name = "Компьютер 4" } };
			SixthPlayer = new PlayerViewModel()
				{ PlayerState = new PlayerState() { Cash = StartCash, IsDealer = false, Name = "Компьютер 5" } };
			_deck = new CardDeck();

			_players.Add(FirstPlayer);
			_players.Add(SecondPlayer);
			_players.Add(ThirdPlayer);
			_players.Add(FourthPlayer);
			_players.Add(FifthPlayer);
			_players.Add(SixthPlayer);
		}

		#endregion
	}
}
