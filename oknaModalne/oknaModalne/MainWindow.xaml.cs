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

namespace oknaModalne
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        { InitializeComponent(); }

        private void Modalne_Click(object sender, RoutedEventArgs e)
        {
            //blokuje pracę w tle

            //MessageBox.Show("Jakiś tekst wyświetlany przy oknie modalnym","Okno modalne", MessageBoxButton.OK);
            Window win = new Window();
            win.ShowDialog();
        }

        private void Niemodalne_Click(object sender, RoutedEventArgs e)
        {
            //nie blokuje pracy w tle
            
            Window win = new Window();
            win.Show();
        }
    }
}
