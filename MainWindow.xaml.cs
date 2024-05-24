using System;
using System.Data;
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

namespace WpfCalc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement uIElement in MainRoot.Children)
            {
                if (uIElement is Button)
                {
                    ((Button)uIElement).Click += Button_Click;
                }
                else
                {

                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = ((Button)e.OriginalSource).Content.ToString();
            switch (str)
            {
                case "C":
                case "CE":
                    {
                        textLabel.Text = "";
                        break;
                    }
                case "Erase":
                    {
                        textLabel.Text = textLabel.Text.Remove(textLabel.Text.Length - 1, 1);
                        break;
                    }
                case "=":
                    {
                        textLabel.Text = new DataTable().Compute(textLabel.Text, null).ToString();
                        break;
                    }
                default:
                    {
                        textLabel.Text += str;
                        break;
                    }
            }
        }
    }
}
