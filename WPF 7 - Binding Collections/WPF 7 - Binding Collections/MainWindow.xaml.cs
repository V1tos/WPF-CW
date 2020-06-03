using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPF_7___Binding_Collections
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> list = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            string[] arr = { "Apple", "Banana", "Cherry", "Barry" };
            foreach (string item in arr)
            {
                list.Add(item);
            }
            lbStudents.ItemsSource = list;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            list.Add("New element");
        }
    }
}
