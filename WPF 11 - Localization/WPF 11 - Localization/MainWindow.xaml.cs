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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_11___Localization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ChangeLang ChangeLang { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ChangeLang = new ChangeLang();
        }

       

        private void Lang_Click(object sender, RoutedEventArgs e)
        {
            MenuItem languageItem = sender as MenuItem;
            ResourceDictionary dictionary = new ResourceDictionary();
            dictionary.Source = new Uri("Properties/"+ languageItem.Tag+".xaml", UriKind.Relative);
            
            MenuItem header = (sender as MenuItem).Parent as MenuItem;
            foreach (MenuItem item in header.Items)
            {
                item.IsChecked = false;
            }
            languageItem.IsChecked = !languageItem.IsChecked;
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(dictionary);
        }

        string[] themesArr = { "light", "dark" };
        private void ChangeThemes(int index)
        {
            ResourceDictionary themesDictionary = new ResourceDictionary();
            themesDictionary.Source = new Uri("Themes/" + themesArr[index] + ".xaml",UriKind.Relative);
            this.Resources.MergedDictionaries.Add(themesDictionary);
        }

        private void Themes_Click(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as MenuItem).Tag);
            ChangeThemes(index);
        }
    }
}
