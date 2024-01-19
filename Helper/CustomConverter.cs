using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMaui
{
    public class CustomConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Syncfusion.Maui.ListView.ItemSelectionChangedEventArgs eventArgs = null;

            if (value is Syncfusion.Maui.ListView.ItemSelectionChangedEventArgs)
            {
                eventArgs = value as Syncfusion.Maui.ListView.ItemSelectionChangedEventArgs;
            }

            return eventArgs;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
