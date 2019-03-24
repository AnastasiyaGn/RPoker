using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Model.Cards;

namespace View.TemplateSelectors
{
	public class CardTemplateSelector : DataTemplateSelector
	{
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			var card = item as Card;
			if (card != null)
			{
				DataTemplate cardTemplate;
				if (card.IsHide)
					cardTemplate = (DataTemplate)Application.Current.Resources["CardShirtDown"];
				else
					cardTemplate = (DataTemplate)Application.Current.Resources[card.ToString()];

				return cardTemplate;
			}

			return null;
		}
	}
}
