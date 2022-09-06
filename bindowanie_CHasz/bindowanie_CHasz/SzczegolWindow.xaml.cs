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
    /// Logika interakcji dla klasy SzczegolWindow.xaml
    /// </summary>
    public partial class SzczegolWindow : Window
    {
        private ListaWindow listaWindow = null;
        public SzczegolWindow()
        {
            InitializeComponent();
        }
        public SzczegolWindow(ListaWindow listaW)
        {
            InitializeComponent();
            this.listaWindow = listaW;
            PrzygotujWiazanie();
        }
        private void PrzygotujWiazanie()
        {
            Produkt produktZListy = listaWindow.listaProd.SelectedItem as Produkt;
            if (produktZListy != null)
            {
                gridProduktSzcz.DataContext = produktZListy;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
