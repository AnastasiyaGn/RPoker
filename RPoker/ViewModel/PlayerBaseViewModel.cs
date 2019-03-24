using System;
using ReactiveUI;
using Model.Players;
using System.Reactive;

namespace ViewModel
{
	public class PlayerBaseViewModel : ReactiveObject
	{
		public PlayerBaseViewModel()
		{
			this.WhenAnyValue(x => x.PlayerState.FirstCard.IsHide).Subscribe(x =>
			{
				PlayerState.RaisePropertyChanged(nameof(PlayerState.FirstCard));
			});

			this.WhenAnyValue(x => x.PlayerState.SecondCard.IsHide).Subscribe(x =>
			{
				PlayerState.RaisePropertyChanged(nameof(PlayerState.SecondCard));
			});

		}

		#region Private properties

		private PlayerState _playerState;
		private bool _canTurn;
		private bool _isFolded;

		#endregion

		#region Public properties

		public bool CanTurn
		{
			get { return _canTurn; }
			set { this.RaiseAndSetIfChanged(ref _canTurn, value, nameof(CanTurn)); }
		}

		public bool IsFolded
		{
			get { return _isFolded; }
			set { this.RaiseAndSetIfChanged(ref _isFolded, value, nameof(IsFolded)); }
		}

		public PlayerState PlayerState
		{
			get { return _playerState; }
			set { this.RaiseAndSetIfChanged(ref _playerState, value, nameof(PlayerState)); }
		}

		public ITableInfo TableInfo { get; set; }

		public ReactiveCommand<Unit, Unit> Fold { get; set; }
		public ReactiveCommand<int, Unit> Raise { get; set; }
		public ReactiveCommand<Unit, Unit> Call { get; set; }

		#endregion




	}
}
