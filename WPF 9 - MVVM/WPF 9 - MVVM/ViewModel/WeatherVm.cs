using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WPF_9___MVVM.Model;
using WPF_9___MVVM.View;
using WPF_9___MVVM.ViewModel.Commands;
using WPF_9___MVVM.ViewModel.Helpers;
using System.Globalization;
using System.Windows.Controls;

namespace WPF_9___MVVM.ViewModel
{
    public class WeatherVm : INotifyPropertyChanged
    {
        private string query;
        private CurrentConditions currentConditions;
        private City selectedCity;
        
        public SearchCommand SearchCommand { get; set; }

        public WeatherVm()
        {
            SearchCommand = new SearchCommand(this);
            Query = "";
        }
        public City SelectedCity
        {
            get => selectedCity;
            set
            {
                selectedCity = value;
                GetConditions();
                OnNotify();
            }
        }
        public CurrentConditions CurrentConditions
        {
            get => currentConditions;
            set
            {
                currentConditions = value;
                OnNotify();
            }
        }
        public ObservableCollection<City> Cities { get; set; } = new ObservableCollection<City>();
        public string Query
        {
            get => query;
            set
            {
                query = value;
                OnNotify();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNotify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public async void MakeRequestCities()
        {
            List<City> cities = await AccuWeatherHelper.GetCities(Query);
            Cities.Clear();
            foreach (var item in cities)
            {
                Cities.Add(item);
            }
        }

        private async void GetConditions()
        {
            if (SelectedCity != null)
            {
                CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(SelectedCity.Key);
            }
            else
                CurrentConditions = new CurrentConditions();
        }


    }

    public class ConvertDayStateToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string dayState = "Day state: ";
            bool isDayTime = System.Convert.ToBoolean(value);

            if (isDayTime)
                dayState += "Day time";
            else
                dayState += "Night time";
            return dayState;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ConvertHasPrecipitationToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string precipitation = "Precipitation: ";
            bool isPrecipitation = System.Convert.ToBoolean(value);

            if (isPrecipitation)
                precipitation += "None";
            else
                precipitation += "Yes";
            return precipitation;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ConvertWeatherIconIntToImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string url = "";
            int imageNumber = System.Convert.ToInt32(value);
            url = $"../img/{imageNumber}.png";
            return url;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
