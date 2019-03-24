using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using ReactiveUI;

namespace ViewModel
{
	public class AIViewModel : PlayerBaseViewModel
	{
		public AIViewModel()
		{
			this.WhenAnyValue(x => x.CanTurn).Subscribe(canTurn =>
			{
				if (canTurn)
					MakeTurn();
			});
		}


		private void MakeTurn()
		{

			
			EndTurn.Execute(PlayerState.Number);
		}

		public ReactiveCommand<int, Unit> EndTurn { get; set; }
	}
}
