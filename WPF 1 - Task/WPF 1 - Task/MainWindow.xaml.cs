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

namespace WPF_1___Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tbFirst.Text = "0";
        }
        string operaTor = "";
        int firstOperand = 0;
        int secondOperand = 0;

        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            Button digit = sender as Button;
            if (tbFirst.Text == "0")
                tbFirst.Text = "";
            tbFirst.Text += digit.Content;
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button btnOperator = sender as Button;
            operaTor = btnOperator.Content.ToString();
            if (secondOperand==0)
            {
                secondOperand = int.Parse(tbFirst.Text);
                tbSecond.Text = secondOperand.ToString() + operaTor;
                tbFirst.Text = "0";
                return;
            }
            tbSecond.Text = Result(operaTor).ToString() + operaTor;
        }

        private int Result(string operaTor)
        {
            firstOperand = int.Parse(tbFirst.Text);

            if (tbSecond.Text == "")
                secondOperand = 0;
            else
                secondOperand = int.Parse(tbSecond.Text.Substring(0, tbSecond.Text.Length - 1));

            tbFirst.Text = "0";


            switch (operaTor)
            {
                case "+":
                    return secondOperand + firstOperand;
                case "-":
                    return secondOperand - firstOperand;
                case "*":
                    return secondOperand * firstOperand;
                case "/":
                    return secondOperand / firstOperand;
                default:
                    return 0;
            }

        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            string result = Result(operaTor).ToString();
            tbFirst.Text = secondOperand + operaTor + firstOperand +  "=" + result;
            tbSecond.Text = "";
        }

        private void FullClear_Click(object sender, RoutedEventArgs e)
        {
            tbSecond.Text = "";
            tbFirst.Text = "0";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            string newText = tbFirst.Text.Remove(tbFirst.Text.Length - 1);
            tbFirst.Text = newText;
            if (tbFirst.Text == "")
                tbFirst.Text = "0";
        }
    }
}
