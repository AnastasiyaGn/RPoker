using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using Model.Players;

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

		#endregion

		#region Public properties

		public bool CanTurn
		{
			get { return _canTurn; }
			set { this.RaiseAndSetIfChanged(ref _canTurn, value, nameof(CanTurn)); }
		}

		public PlayerState PlayerState
		{
			get { return _playerState; }
			set { this.RaiseAndSetIfChanged(ref _playerState, value, nameof(PlayerState)); }
		}

		#endregion

	}
}
