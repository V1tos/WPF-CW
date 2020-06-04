using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WPF_10___Contacts__MVVM_.ViewModel.Convertors
{
    public class ConvertBoolToVisible : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isCollapsed = System.Convert.ToBoolean(value);
            Visibility visibility = new Visibility();
            if (isCollapsed)
                visibility = Visibility.Visible;
            else
                visibility = Visibility.Collapsed;

            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            throw new NotImplementedException();
        }
    }
}
