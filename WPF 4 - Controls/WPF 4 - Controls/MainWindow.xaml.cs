using Microsoft.Win32;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_4___Controls
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

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            lblDate.Content = calendar.SelectedDate.Value.ToShortDateString();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog()==true)
            {
                media.Source = new Uri(ofd.FileName);
                slider.Value = media.Volume;
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            
            //media.Po
            media.Play();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            media.Pause();
        }

        private void AddVolume_Click(object sender, RoutedEventArgs e)
        {
            if (media.Volume > 0.9)
                return;
            media.Volume += 0.1;
        }

        private void CastVolume_Click(object sender, RoutedEventArgs e)
        {
            if (media.Volume < 0.1)
                return;
            media.Volume -= 0.1;
        }

       
    }
}
