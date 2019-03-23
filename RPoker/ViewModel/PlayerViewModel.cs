using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using Model.Players;

namespace ViewModel
{
	public class PlayerViewModel : ReactiveObject
	{
		public PlayerViewModel()
		{
			PlayerState = new PlayerState();


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

		#endregion

		#region Public properties

		public PlayerState PlayerState
		{
			get { return _playerState; }
			set { this.RaiseAndSetIfChanged(ref _playerState, value, nameof(PlayerState)); }
		}

		#endregion

	}
}
