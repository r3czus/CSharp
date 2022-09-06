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

namespace bindowanie_CHasz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Produkt p1 = null;
        public MainWindow()
        {
            InitializeComponent();
            PrzygotujWiazanie();
        }

        private void PrzygotujWiazanie()
        {
            p1 = new Produkt("st", "ser topiony", 200, "Gliwice");
            gridProdukt.DataContext = p1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(p1.ToString());
        }
    }
}
