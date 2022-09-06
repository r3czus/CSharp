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

namespace listViewW1Oknie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal ObservableCollection<Osoba> ListaOsob = null;
        public MainWindow()
        {
            InitializeComponent();
            PrzygotujWiązanie();
            formularz.BindingGroup.BeginEdit();
        }

        private void PrzygotujWiązanie()
        {
            ListaOsob = new ObservableCollection<Osoba>();
            ListaOsob.Add(new Osoba("Andrzej", "Szyba", "3a"));
            ListaOsob.Add(new Osoba("Roman", "Gęś", "8c"));
            ListaOsob.Add(new Osoba("Jędrzej", "Krzywy", "5b"));
            ListaOsob.Add(new Osoba("Olimpia", "Helladzka", "1a"));
            ListaOsob.Add(new Osoba("Wok", "Cena", "9c"));
            listw.ItemsSource = ListaOsob;
        }

        private void listw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Osoba zaznaczony = listw.SelectedItem as Osoba;
            formularz.DataContext = zaznaczony;
        }

        private void Button_Click_Usun(object sender, RoutedEventArgs e)
        {
            Osoba OsobaZListy = listw.SelectedItem as Osoba;
            MessageBoxResult odpowiedz = MessageBox.Show("Czy na pewno usunąć osobę " + OsobaZListy.ToString() + " ?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (odpowiedz == MessageBoxResult.Yes)
            { ListaOsob.Remove(OsobaZListy); }
        }

        private void Button_Click_Zmien(object sender, RoutedEventArgs e)
        {
            formularz.BindingGroup.CommitEdit();
            formularz.BindingGroup.BeginEdit();
        }

        private void Button_Click_Dodaj(object sender, RoutedEventArgs e)
        {
            if (imie.Text != "" && nazwisko.Text != "" && klasa.Text != "")
            {
                ListaOsob.Add(new Osoba(imie.Text, nazwisko.Text, klasa.Text));
                formularz.DataContext = null;
            }
        }
    }
}
