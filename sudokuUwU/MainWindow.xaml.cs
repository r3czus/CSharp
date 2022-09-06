using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace sudokuUwU
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<pole> czwórka { get; set; }
        public ObservableCollection<pole> dziewiątka { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            przygotowania();
            DataContext = this;
        }

        void przygotowania()
        {
            int i = 0, kolumna = 0, wiersz = 0, wartość = 1, s = 0;
            bool readOnly = false;
            string kolor = "white";
            
            czwórka = new ObservableCollection<pole>();
            int[] koloroweCzwórki = new int[] { 0, 1,  4, 5,  10, 11,  14, 15 };
            int[] sztywnePolaCzwórki = new int[] { 0, 7, 10, 13 };
            int[] sztywnePolaWartościCzwórki = new int[] { 1, 4, 2, 3 };
            for (i = 0; i < 16; i++)
            {
                kolor = "white";
                wartość = 1;
                readOnly = false;
                if (koloroweCzwórki.Contains(i))
                { kolor = "lightblue"; }
                if(sztywnePolaCzwórki.Contains(i))
                {
                    wartość = sztywnePolaWartościCzwórki[s];
                    readOnly = true;
                    s++;
                }
                czwórka.Add(new pole(wartość, readOnly, kolor));
            }

            i = kolumna = wiersz = s = 0; 
            wartość = 1;
            dziewiątka = new ObservableCollection<pole>();
            int[] koloroweDziewiątki = new int[] { 0, 1, 2,  6, 7, 8,  9, 10, 11,  15, 16, 17,  18, 19, 20,  24, 25, 26,  30, 31, 32,  39, 40, 41,  48, 49, 50,  54, 55, 56,  60, 61, 62,  63, 64, 65,  69, 70, 71,  72, 73, 74,  78, 79, 80};
            int[] sztywnePolaDziewiątki = new int[] { 1, 3, 5, 9, 10, 14, 15, 22, 27, 28, 33, 36, 44, 47, 52, 53, 58, 65, 66, 70, 71, 75, 77, 79 };
            int[] sztywnePolaWartościDziewiątki = new int[] { 2, 6, 8, 5, 8, 9, 7, 4, 3, 7, 5, 6, 4, 8, 1, 3, 2, 9, 8, 3, 6, 3, 6, 9 };
            for (i = 0; i < 81; i++)
            {
                kolor = "white";
                wartość = 1;
                readOnly = false;
                if (koloroweDziewiątki.Contains(i))
                { kolor = "lightblue"; }
                if (sztywnePolaDziewiątki.Contains(i))
                {
                    wartość = sztywnePolaWartościDziewiątki[s];
                    readOnly = true;
                    s++;
                }
                dziewiątka.Add(new pole(wartość, readOnly, kolor));
            }
        }

        private void PreviewTextInputFour(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[1-4]*$");
            e.Handled = !regex.IsMatch(e.Text);
        }        
        private void PreviewTextInputNine(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[1-9]*$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(taby.SelectedIndex == 0)
            { weryfikacja(czwórka); }
            else
            { weryfikacja(dziewiątka); }
        }

        private void weryfikacja(ObservableCollection<pole> tablica)
        {
            graCztery.BorderBrush = Brushes.Black;
            graDziewięć.BorderBrush = Brushes.Black;

            double rozmiar = Math.Sqrt(tablica.Count);

            int numer = 0, wiersz = 0, kolumna = 0, i = 0;
            int[,] matryca = new int[(int)rozmiar, (int)rozmiar];
            for (wiersz = 0; wiersz < rozmiar; wiersz++)
            {
                for (kolumna = 0; kolumna < rozmiar; kolumna++)
                {
                    numer = tablica[i].Liczba;
                    if (numer == 0)
                    { MessageBox.Show("Proszę wpisać brakującą liczbę!"); return; }
                    matryca[wiersz, kolumna] = numer;
                    i++;
                }
            }

            if (pasek(matryca, true, rozmiar) == true)
            {
                if(pasek(matryca, false, rozmiar) == true)
                {
                    int miniRozmiar = (int)Math.Sqrt(rozmiar);
                    int bigKolumna = 0, bigWiersz = 0, modWiersz = 0, modKolumna = 0, j = 0, x = 0;

                    for (bigKolumna = 0; bigKolumna < rozmiar; bigKolumna += miniRozmiar)
                    {
                        int[] kratka = new int[(int)rozmiar];
                        x = 0;
                        for (wiersz = 0; wiersz < miniRozmiar; wiersz++)
                        {
                            modWiersz = bigWiersz + wiersz;
                            for (kolumna = 0; kolumna < miniRozmiar; kolumna++)
                            {
                                modKolumna = bigKolumna + kolumna;
                                kratka[x] = matryca[modWiersz, modKolumna];
                                x++;
                            }
                        }
                        if (kratka.Length != kratka.Distinct().Count())
                        { MessageBox.Show("Jeden z kwadratów zawiera duplikat."); return; }
                        j++;
                        if(j == miniRozmiar)
                        {
                            bigKolumna = 0;
                            bigWiersz += miniRozmiar;
                            j = 0;
                        }
                    }

                    if (miniRozmiar == 2)
                    {  graCztery.BorderBrush = Brushes.Lime; }
                    else
                    { graDziewięć.BorderBrush = Brushes.Lime; }
                }
                else { return; }
            }
            else { return; }
        }

        private bool pasek(int[,] kwadrat, bool poziomo, double wymiar)
        {
            int kierunek1 = 0, kierunek2 = 0;
            int[] pasek = new int[(int)wymiar];
            string ktory = "";
            for (kierunek1 = 0; kierunek1 < wymiar; kierunek1++)
            {
                for (kierunek2 = 0; kierunek2 < wymiar; kierunek2++)
                {
                    if (poziomo == true)
                    { pasek[kierunek2] = kwadrat[kierunek1, kierunek2]; }
                    else 
                    { pasek[kierunek2] = kwadrat[kierunek2, kierunek1]; }
                }

                if (pasek.Length != pasek.Distinct().Count())
                {
                    if(poziomo == true)
                    { ktory = "Wiersz "; }
                    else
                    { ktory = "Kolumna "; }
                    int duplo = ++kierunek1;
                    MessageBox.Show(ktory + duplo.ToString() + " zawiera duplikat"); return false;
                }
            }
            return true;

            //Oryginalna metoda sprawdzania powtórzeń w wierszach i kolumnach używana w weryfikacji()
            /*
                int[] pasek = new int[rozmiar];
                for (wiersz = 0; wiersz < rozmiar; wiersz++)
                {
                    for (kolumna = 0; kolumna < rozmiar; kolumna++)
                    { pasek[kolumna] = matryca[wiersz, kolumna]; }

                    if (pasek.Length != pasek.Distinct().Count())
                    {
                        int duplo = ++wiersz;
                        MessageBox.Show("Wiersz " + duplo.ToString() + " zawiera duplikat"); return;
                    }
                }
                for (kolumna = 0; kolumna < rozmiar; kolumna++)
                {
                    for (wiersz = 0; wiersz < rozmiar; wiersz++)
                    { pasek[wiersz] = matryca[wiersz, kolumna]; }

                    if (pasek.Length != pasek.Distinct().Count())
                    {
                        int duplo = ++kolumna;
                        MessageBox.Show("Kolumna " + duplo.ToString() + " zawiera duplikat"); return;
                    }
                }
            */
        }
    }
}

