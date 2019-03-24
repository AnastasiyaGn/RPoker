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
using Model.Players;

namespace View
{
	/// <summary>
	/// Логика взаимодействия для PlayerInterfaceWindow.xaml
	/// </summary>
	public partial class PlayerInterfaceWindow : Window
	{
		public PlayerInterfaceWindow()
		{
			InitializeComponent();

			var vm = new PlayerViewModel();
			vm.PlayerState = new PlayerState()
			{
				FirstCard = new Card(CardSuit.Diamond, CardRank.Five),
				SecondCard = new Card(CardSuit.Spade, CardRank.Ace),
				Cash = 10000,
				IsBigBlind = true,
				IsDealer = true,
				IsSmallBlind = true,
				Name = "Игрок",
				Number = 0
			};

			DataContext = vm;


		}
	}
}
