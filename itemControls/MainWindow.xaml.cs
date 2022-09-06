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

namespace itemControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Produkt> ListaProduktów { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            ListaProduktów = new List<Produkt>();
            ListaProduktów.Add(new Produkt("farby", 12, true));
            ListaProduktów.Add(new Produkt("kredki", 20, true));
            ListaProduktów.Add(new Produkt("blok", 5, false));
            ListaProduktów.Add(new Produkt("ołówek", 2, true));
            ListaProduktów.Add(new Produkt("ołówekB5", 2, true));
            ListaProduktów.Add(new Produkt("ołówekB2", 2, true));
            ListaProduktów.Add(new Produkt("ołówekb", 2, true));
            ListaProduktów.Add(new Produkt("ołówekHB", 2, true));
            ListaProduktów.Add(new Produkt("ołówekH3", 2, true));
        }
    }
}
