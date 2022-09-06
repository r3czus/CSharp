using notifyPropertyChanged.ViewModels;
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

namespace notifyPropertyChanged
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel main = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = main;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { main.SetBackground(Brushes.Red); }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { main.SetBackground(Brushes.Blue); }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        { main.SetBackground(Brushes.Green); }
    }
}
