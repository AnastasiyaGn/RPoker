using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace View.TemplateSelectors
{
    class ButtonTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var button = item;
            if (button != null)
            {
                DataTemplate buttonTemplate;
                buttonTemplate = (DataTemplate)Application.Current.Resources[button.ToString()];

                return buttonTemplate;
            }

            return null;
        }
    }
}
