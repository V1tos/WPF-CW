using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_11___Localization
{
    public class ChangeLang : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
            ResourceDictionary dictionary = new ResourceDictionary();
            dictionary.Source = new Uri("Properties/" + parameter.ToString()+ ".xaml", UriKind.Relative);

            //MenuItem header = (sender as MenuItem).Parent as MenuItem;
            //foreach (MenuItem item in header.Items)
            //{
            //    item.IsChecked = false;
            //}
            //languageItem.IsChecked = !languageItem.IsChecked;
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }
    }
}