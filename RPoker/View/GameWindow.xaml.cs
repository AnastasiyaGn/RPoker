using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model.Cards;
using ViewModel;
using ReactiveUI;
using System.Reactive.Disposables;

namespace View
{
	/// <summary>
	/// Логика взаимодействия для GameWindow.xaml
	/// </summary>
	public partial class GameWindow : ReactiveWindow<GameViewModel>
	{
		public GameWindow()
		{
			InitializeComponent();

			ViewModel = new GameViewModel();

			ViewModel.DoFlopCard();
			ViewModel.DealCards();

			this.WhenActivated(d =>
			{
				this.OneWayBind(ViewModel, vm => vm.FirstPlayer, v => v.xPlayer1.ViewModel).DisposeWith(d);

				this.OneWayBind(ViewModel, vm => vm.Pot, v => v.xPot.Text, x => $"Pot: {x}").DisposeWith(d);

				this.OneWayBind(ViewModel, vm => vm.FlopCard1, v => v.xFlopCard1.Content).DisposeWith(d);
				this.OneWayBind(ViewModel, vm => vm.FlopCard2, v => v.xFlopCard2.Content).DisposeWith(d);
				this.OneWayBind(ViewModel, vm => vm.FlopCard3, v => v.xFlopCard3.Content).DisposeWith(d);
				this.OneWayBind(ViewModel, vm => vm.TurnCard, v => v.xTurnCard.Content).DisposeWith(d);
				this.OneWayBind(ViewModel, vm => vm.RiverCard, v => v.xRiverCard.Content).DisposeWith(d);

			});

		}
	}


}
