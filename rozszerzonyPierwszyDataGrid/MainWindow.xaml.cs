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

namespace rozszerzonyPierwszyDataGrid
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

            //string ścieżka = "C:/Users/3a1/Desktop/pierwszyZdalneDataGrid/rysunki/";
            string ścieżka = "E:/Rzeczy szkolne/Programowanie/C#/rozszerzonyPierwszyDataGrid/rysunki/";
            listaProduków = new ObservableCollection<Produkt>();
            listaProduków.Add(new Produkt("trumpki", 50, true, "buty", new Uri(ścieżka + "trumpki.png")));
            listaProduków.Add(new Produkt("szalik", 50, true, "dodatki", new Uri(ścieżka + "szalik.png")));
            listaProduków.Add(new Produkt("rękawiczki", 30, true, "dodatki", new Uri(ścieżka + "rekawiczki.png")));
            listaProduków.Add(new Produkt("okulary słoneczne", 130, false, "dodatki", new Uri(ścieżka + "okulary.png")));
            listaProduków.Add(new Produkt("kozaki", 150, false, "buty", new Uri(ścieżka + "kozaki.png")));
            dataGridProdukty.ItemsSource = listaProduków;
        }
    }
}
