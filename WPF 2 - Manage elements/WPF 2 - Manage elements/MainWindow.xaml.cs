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

namespace WPF_2___Manage_elements
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Hover_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Background = Brushes.Green;
            (sender as Button).Foreground = Brushes.White;
            Title = "Hover";
        }

        private void Press_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Background = Brushes.Green;
            (sender as Button).Foreground = Brushes.White;
            Title = "Press";
        }

        private void Release_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Background = Brushes.Green;
            (sender as Button).Foreground = Brushes.White;
            Title = "Release";
        }

        private void Checked_Changed(object sender, RoutedEventArgs e)
        {
            Title = "Checked";
        }
    }
}
