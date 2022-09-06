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

namespace przywitanie
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Witaj");
            
        }

        private void Czas_button_MouseEnter(object sender, MouseEventArgs e)
        {
           DateTime data = DateTime.Now;
           Czas_button.Content = data.ToString("T");
        }

        private void Czas_button_MouseLeave(object sender, MouseEventArgs e)
        {
            Czas_button.Content = "Czas";
        }
    }
}
