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
