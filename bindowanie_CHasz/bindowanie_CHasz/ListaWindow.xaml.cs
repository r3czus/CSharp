using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; //Dodane przez alt+Enter na linijce 23
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
    /// Logika interakcji dla klasy ListaWindow.xaml
    /// </summary>
    public partial class ListaWindow : Window
    {
        internal ObservableCollection<Produkt> ListaProduktów = null;
        public ListaWindow()
        {
            InitializeComponent();
            PrzygotujWiązanie();
        }

        private void PrzygotujWiązanie()
        {
            ListaProduktów = new ObservableCollection<Produkt>();
            ListaProduktów.Add(new Produkt("ch", "chlebek", 200, "Zabrze"));
            ListaProduktów.Add(new Produkt("ok", "ogórki kiszone", 100, "Zabrze"));
            ListaProduktów.Add(new Produkt("ok", "papryka", 50, "Zabrze"));
            ListaProduktów.Add(new Produkt("st", "serek topiony", 150, "Gliwice"));
            listaProd.ItemsSource = ListaProduktów;
        }

        private void listaProd_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SzczegolWindow SzczOkno = new SzczegolWindow(this);
            SzczOkno.ShowDialog();
        }

        private void listaProd_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Produkt produktZListy = listaProd.SelectedItem as Produkt;
            MessageBoxResult odpowiedz = MessageBox.Show("Czy na pewno usunąć produkt " + produktZListy.ToString() + " ?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(odpowiedz == MessageBoxResult.Yes)
            {
                //MessageBox.Show("Usuwamy");
                ListaProduktów.Remove(produktZListy);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodajWindow oknoDodaj = new DodajWindow(this);
            oknoDodaj.ShowDialog(); 
        }
    }
}
