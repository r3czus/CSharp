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
using System.Windows.Shapes;

namespace bindowanie_CHasz
{
    /// <summary>
    /// Logika interakcji dla klasy DodajWindow.xaml
    /// </summary>
    public partial class DodajWindow : Window
    {
        ListaWindow listaWindow = null;
        public DodajWindow()
        {
            InitializeComponent();
        }
        public DodajWindow(ListaWindow listaW)
        {
            InitializeComponent();
            listaWindow = listaW;
            PrzygotujWiazanie();
        }
        private void PrzygotujWiazanie()
        {
            Produkt nowyProdukt = new Produkt("jakiś symbol", "jakaś nazwa", 0, "kajś");
            dodajDane.DataContext = nowyProdukt;
            listaWindow.ListaProduktów.Add(nowyProdukt);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
