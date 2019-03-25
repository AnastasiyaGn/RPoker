using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewModel;
using ReactiveUI;
using System.Reactive.Disposables;

namespace View
{
	/// <summary>
	/// Логика взаимодействия для AIView.xaml
	/// </summary>
	public partial class AIView : ReactiveUserControl<AIViewModel>
	{
		public AIView()
		{
			InitializeComponent();

			this.WhenActivated(d =>
			{
				this.OneWayBind(ViewModel, vm => vm.PlayerState.FirstCard, v => v.xFirstCard.Content).DisposeWith(d);
				this.OneWayBind(ViewModel, vm => vm.PlayerState.SecondCard, v => v.xSecondCard.Content).DisposeWith(d);
				this.OneWayBind(ViewModel, vm => vm.PlayerState.Cash, v => v.xCash.Text, cash => cash.ToString()).DisposeWith(d);
				this.OneWayBind(ViewModel, vm => vm.PlayerState.Name, v => v.xPlayerName.Text);

				this.OneWayBind(ViewModel, vm => vm.PlayerState.IsDealer, v => v.xIsDealer.Visibility, x =>
				{
					var conv = new BooleanToVisibilityConverter();
					return (Visibility)conv.Convert(x, typeof(Visibility), null, System.Globalization.CultureInfo.CurrentCulture);
				}).DisposeWith(d);

				this.OneWayBind(ViewModel, vm => vm.PlayerState.IsSmallBlind, v => v.xIsSmallBlind.Visibility, x =>
				{
					var conv = new BooleanToVisibilityConverter();
					return (Visibility)conv.Convert(x, typeof(Visibility), null, System.Globalization.CultureInfo.CurrentCulture);
				}).DisposeWith(d);

				this.OneWayBind(ViewModel, vm => vm.PlayerState.IsBigBlind, v => v.xIsBigBlind.Visibility, x =>
				{
					var conv = new BooleanToVisibilityConverter();
					return (Visibility)conv.Convert(x, typeof(Visibility), null, System.Globalization.CultureInfo.CurrentCulture);
				}).DisposeWith(d);
			});
		}
	}
}
