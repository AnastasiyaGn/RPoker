using System;
using System.Collections.Generic;
using System.Text;
using Model.Players;
using ReactiveUI;

namespace ViewModel
{
	public class GameViewModel : ReactiveObject
	{
		public GameViewModel()
		{
			Bank = 0;
			MinBet = 50;
			StartCash = 10000;

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

			_players.Add(FirstPlayer);
			_players.Add(SecondPlayer);
			_players.Add(ThirdPlayer);
			_players.Add(FourthPlayer);
			_players.Add(FifthPlayer);
			_players.Add(SixthPlayer);

		}

		#region Private fields

		private List<PlayerViewModel> _players;
		private int _bank;
		private int _minBet;
		private int _startCash;

		#endregion

		#region Public properties

		public int Bank
		{
			get { return _bank; }
			set { this.RaiseAndSetIfChanged(ref _bank, value, nameof(Bank)); }
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

		public PlayerViewModel FirstPlayer { get; set; }
		public PlayerViewModel SecondPlayer { get; set; }
		public PlayerViewModel ThirdPlayer { get; set; }
		public PlayerViewModel FourthPlayer { get; set; }
		public PlayerViewModel FifthPlayer { get; set; }
		public PlayerViewModel SixthPlayer { get; set; }

		#endregion


		
	}
}
