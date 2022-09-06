using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace konweter_2osiem10hex
{
    public partial class MainWindow : Window
    {
        public ComboBoxItem boxik;
        public string wybrany;
        public int susBazowy;
        public bool gotowe = false;
        public Regex regex = new Regex(@"^\d$");

        public MainWindow()
        { InitializeComponent(); }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (liczbaBox.Text != "")
            {
                string pierwotna = liczbaBox.Text;
                pierwotna = pierwotna.Replace(" ", String.Empty);
                pierwotna = pierwotna.ToUpper();

                ComboBoxItem boxik = (ComboBoxItem)jakiJest.SelectedItem;
                string wybrany = boxik.Content.ToString();
                int susBazowy = Int32.Parse(wybrany);

                boxik = (ComboBoxItem)jakiMaByć.SelectedItem;
                wybrany = boxik.Content.ToString();
                int susDocelowy = Int32.Parse(wybrany);
                int d = pierwotna.Length, cyfra = 0;
                long potega = 1, wynik = 0, reszta = 0;
                string ostatnia = "", final = "";

                if (pierwotna != "0")
                {
                    if (susBazowy != 10)
                    {
                        while (d > 0)
                        {
                            ostatnia = pierwotna[d - 1].ToString();
                            if (ostatnia == "A")
                            { cyfra = 10; }
                            else if (ostatnia == "B")
                            { cyfra = 11; }
                            else if (ostatnia == "C")
                            { cyfra = 12; }
                            else if (ostatnia == "D")
                            { cyfra = 13; }
                            else if (ostatnia == "E")
                            { cyfra = 14; }
                            else if (ostatnia == "F")
                            { cyfra = 15; }
                            else
                            { cyfra = Int32.Parse(ostatnia); }
                            wynik += cyfra * potega;
                            potega *= susBazowy;
                            d--;
                        }
                    }
                    else
                    { wynik = Int32.Parse(pierwotna); }
                    if (susDocelowy == 10)
                    { final = wynik.ToString(); }
                    else
                    {
                        string resztaStr = "", koniec = "", bezSpacji = "";
                        while (wynik > 0)
                        {
                            reszta = wynik % susDocelowy;
                            wynik /= susDocelowy;
                            if (reszta == 10)
                            { resztaStr = "A"; }
                            else if (reszta == 11)
                            { resztaStr = "B"; }
                            else if (reszta == 12)
                            { resztaStr = "C"; }
                            else if (reszta == 13)
                            { resztaStr = "D"; }
                            else if (reszta == 14)
                            { resztaStr = "E"; }
                            else if (reszta == 15)
                            { resztaStr = "F"; }
                            else
                            { resztaStr = reszta.ToString(); }
                            koniec = resztaStr.ToString() + koniec;
                        }
                        if (susDocelowy == 2)
                        {
                            int przerwa = 0, dlugosc = koniec.Length;
                            for (int i = dlugosc - 1; i >= 0; i--)
                            {
                                if (przerwa == 4)
                                {
                                    przerwa = 0;
                                    final = " " + final;
                                }
                                final = koniec[i] + final;
                                przerwa++;
                            }
                            while (dlugosc % 4 != 0)
                            {
                                final = "0" + final;
                                bezSpacji = String.Concat(final.Where(c => !Char.IsWhiteSpace(c)));
                                dlugosc = bezSpacji.Length;
                            }
                        }
                        else
                        { final = koniec; }
                    }
                }
                else
                { final = "0"; }
                naSystem.Text = "na system " + susDocelowy.ToString() + ": ";
                wynikowy.Text = final.ToString();
            }
            else
            { MessageBox.Show("Podaj jakąś liczbę, by móc ją przekonwertować!", "Brak liczby", MessageBoxButton.OK, MessageBoxImage.Warning); }
        }

        private void Regeks(object sender, TextCompositionEventArgs e)
        {
            switch (susBazowy)
            {
                case 2:
                    regex = new Regex("^[0-1]*$");
                    break;
                case 8:
                    regex = new Regex("^[0-7]*$");
                    break;
                case 16:
                    regex = new Regex("^[0-9]*[A-F]*[a-f]*$");
                    break;
                default:
                    regex = new Regex(@"^\d$");
                    break;
            }
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void jakiJest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { aktualizacja(); }

        public void aktualizacja()
        {
            if(gotowe == true)
            {
                boxik = (ComboBoxItem)jakiJest.SelectedItem;
                wybrany = boxik.Content.ToString();
                susBazowy = Int32.Parse(wybrany);
            }
            else
            { gotowe = true; }
        }
    }
}
