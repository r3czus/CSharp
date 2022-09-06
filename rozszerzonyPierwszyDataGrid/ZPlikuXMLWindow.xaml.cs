using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Linq;

namespace rozszerzonyPierwszyDataGrid
{
    /// <summary>
    /// Logika interakcji dla klasy ZPlikuXMLWindow.xaml
    /// </summary>
    public partial class ZPlikuXMLWindow : Window
    {
        private string plik1 = @"..\..\..\dane\Produkty.xml";
        private string plik2 = @"..\..\..\dane\Produkty2.xml";
        private XElement wykazProduktow;
        private ObservableCollection<string> listaKategorii = null;

        public ZPlikuXMLWindow()
        {
            InitializeComponent();
            PrzygotujWiązanie();
        }

        private void PrzygotujWiązanie()
        {

            if (File.Exists(plik1))
            {
                wykazProduktow = XElement.Load(plik1);
                dataGridProdukty.DataContext = wykazProduktow;
                listaKategorii = new ObservableCollection<string>() { "Buty", "Ubrania", "Dodatki" };
                kategorieComboBox.ItemsSource = listaKategorii;
            }
            else
            { MessageBox.Show("Plik nie istnieje."); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { wykazProduktow.Save(plik2); }
    }
}
