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

namespace WPF_8___Static_Resource
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SomeClass some = new SomeClass() { MyProperty = "Property from code behind", MyProperty2="Other property from code behind"};
        public SomeClass some2 = new SomeClass() { MyProperty = "Property2 from code behind", MyProperty2="Other property2 from code behind"};
        public SomeClass Some
        {
            get => some2;
            set
            {
                some2 = value;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = some;
        }
 

     
    }
    public class SomeClass
        {
            public string MyProperty { get; set; }
            public string MyProperty2 { get; set; }
        }
}
