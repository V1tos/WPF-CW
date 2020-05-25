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

namespace WPF_3___Expander
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
        bool visibility = false;
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (!visibility)
                answersPanel.Visibility = Visibility.Visible;
            else
                answersPanel.Visibility = Visibility.Hidden;
            visibility = !visibility;
            
        }

        private void LineUp_Click(object sender, RoutedEventArgs e)
        {
            scroll.LineUp();
        }

        private void LineDown_Click(object sender, RoutedEventArgs e)
        {
            scroll.LineDown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Expander_Expamded(object sender, RoutedEventArgs e)
        {
            SpellingError spellingError = tBox.GetSpellingError(tBox.CaretIndex);
            foreach (var item in spellingError.Suggestions)
            {
                spellList.Items.Add(item);
            }
        }

        private void Expander_Colapsed(object sender, RoutedEventArgs e)
        {

        }
    }
}
