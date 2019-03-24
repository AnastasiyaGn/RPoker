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
using Model.Cards;
using Model.Players;
using ViewModel;

namespace View
{
	/// <summary>
	/// Логика взаимодействия для AIViewWindow.xaml
	/// </summary>
	public partial class AIViewWindow : Window
	{
		public AIViewWindow()
		{
			InitializeComponent();

			var vm = new AIViewModel();
			vm.PlayerState = new PlayerState()
			{
				Cash = 500,
				FirstCard = new Card(CardSuit.Club, CardRank.Eight),
				SecondCard = new Card(CardSuit.Hearth, CardRank.Nine),
				IsBigBlind = true,
				IsDealer = false,
				IsSmallBlind = false,
				Name = "Компьютер 2",
				Number = 2
			};

			DataContext = vm;


		}
	}
}
