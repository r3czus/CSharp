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

namespace kontrolki_numer_2
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

        private void chk_ws_Checked(object sender, RoutedEventArgs e)
        {
            chk1.IsChecked = chk2.IsChecked = chk3.IsChecked = (sender as CheckBox).IsChecked;
        }
        private void chk_x_Checked(object sender, RoutedEventArgs e)
        {
            if(chk1.IsChecked == true && chk2.IsChecked == true && chk3.IsChecked == true)
            { chk_ws.IsChecked = true; }
            else if (chk1.IsChecked == true || chk2.IsChecked == true || chk3.IsChecked == true)
            { chk_ws.IsChecked = null; }
            else
            { chk_ws.IsChecked = false; }
        }
    }
}
