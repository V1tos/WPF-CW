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

namespace WPF_5___Controls_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Run run = new Run("Hello, first run");
            Bold bold = new Bold();
            Run run2 = new Run();
            run2.Text = "dynamically text run";
            bold.Inlines.Add(run2);

            Italic italic = new Italic(new Run("Hello, italic"));
            Underline underline = new Underline();
            underline.Inlines.Add(new Run("Underline"));

            Span span = new Span();
            span.Inlines.Add(run);
            span.Inlines.Add(bold);
            span.Inlines.Add(italic);
            span.Inlines.Add(underline);

            label.Content = span;
        }
    }
}
