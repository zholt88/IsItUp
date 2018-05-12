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
using IsItUpCore;

namespace IsItUpApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUpChecker _upChecker = new SimpleUpChecker();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isUp = await _upChecker.IsItUpAsync(TextBox.Text);
            if (isUp)
            {
                TextBlock1.Background = Brushes.Green;
                TextBlock1.Text = "Yes!";
            }
            else
            {
                TextBlock1.Background = Brushes.Red;
                TextBlock1.Text = "No :(";
            }
        }
    }
}
