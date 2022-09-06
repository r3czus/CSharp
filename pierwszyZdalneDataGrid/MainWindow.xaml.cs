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

namespace pierwszyZdalneDataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Produkt> listaProduków = null;
        private ObservableCollection<string> listaKategorii = null;

        public MainWindow()
        {
            InitializeComponent();
            przygotujWiązanie();
        }

        private void przygotujWiązanie()
        {
            listaKategorii = new ObservableCollection<string>() { "buty", "ubrania", "dodatki" };
            kategorieComboBox.ItemsSource = listaKategorii;
            listaProduków = new ObservableCollection<Produkt>();
            listaProduków.Add(new Produkt("trumpki", 50, true, "buty"));
            listaProduków.Add(new Produkt("spodnie", 50, true, "ubrania"));
            listaProduków.Add(new Produkt("rękawiczki", 30, true, "dodatki"));
            listaProduków.Add(new Produkt("okulary słoneczne", 130, false, "dodatki"));
            listaProduków.Add(new Produkt("kozaki", 150, false, "buty"));
            dataGridProdukty.ItemsSource = listaProduków;
        }
    }
}
