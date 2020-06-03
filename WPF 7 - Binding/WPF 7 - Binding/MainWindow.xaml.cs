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

namespace WPF_7___Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Binding binding = new Binding()
            {
                ElementName = "slider2",
                Path = new PropertyPath("Value"),
                Mode = BindingMode.TwoWay
            };
            label2.SetBinding(Label.FontSizeProperty, binding);
            Binding bndColor = new Binding()
            {
                ElementName = "text",
                Path = new PropertyPath("Text"),
            };
            label2.SetBinding(Label.ForegroundProperty, bndColor);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            label.FontSize = 30;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            label2.ClearValue(Label.FontSizeProperty);
        }
    }
}
