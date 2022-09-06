using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace heheZartSzefa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random r = new Random();
        public int x { get; set; }
        public int y { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            x = 80;
            y = 180;
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { this.Close(); }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            x = r.Next(0, 489);
            y = r.Next(0, 235);
            Canvas.SetRight(tak, x);
            Canvas.SetTop(tak, y);

            // this.Left = r.Next(0, 1320);
            // this.Right = r.Next(0, 730);
            // this.Show();
        }
    }
}
