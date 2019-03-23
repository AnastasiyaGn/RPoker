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

namespace View
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
	{
        public GameWindow()
		{
			InitializeComponent();
		}
    }
    public class BalanceTypesTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Template1 { get; set; }
        public DataTemplate Template2 { get; set; }
        public DataTemplate Template3 { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //var type = item.ToString();
            return Template2;
            //switch (type)
            //{
            //    case "t1":
            //        return Template1;
            //    case "t2":
            //        return Template1;
            //    case "t3":
            //        return Template3;
            //    default:
            //        throw new NotSupportedException();
            //}
        }
    }
}
