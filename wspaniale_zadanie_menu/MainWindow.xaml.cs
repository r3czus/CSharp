using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace wspaniale_zadanie_menu
{
    public partial class MainWindow : Window
    {
        private string? sciezka = null;
        int? najw = null, najm = null, l1 = null, l2 = null;
        public MainWindow()
        { InitializeComponent(); }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(najm != null && najw != null)
            {
                string wyniki = "Wyniki obliczania NWD i NWW dla liczb " + tbx1.Text + " oraz " + tbx2.Text + " :\nNWD: " + najw.ToString() + "\nNWW: " + najm.ToString();

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "PlainText | *.txt";
                dialog.Title = "Zapisywanie";
                if (dialog.ShowDialog() == true)
                {
                    sciezka = dialog.FileName;
                    File.WriteAllText(sciezka, wyniki);
                }
            }
            else
            { MessageBox.Show("Wpierw oblicz jakieś NWD i NWW!"); }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            tbx1.Text = "";
            tbx2.Text = "";
            nwd.Text = "NWD: ";
            nww.Text = "NWW: ";
        }

        private void SizeLarge_Click(object sender, RoutedEventArgs e)
        { tbk1.FontSize = tbk2.FontSize = tbx1.FontSize = tbx2.FontSize = nwd.FontSize = nww.FontSize = b1.FontSize = b2.FontSize = 24; }

        private void SizeSmall_Click(object sender, RoutedEventArgs e)
        { tbk1.FontSize = tbk2.FontSize = tbx1.FontSize = tbx2.FontSize = nwd.FontSize = nww.FontSize = b1.FontSize = b2.FontSize = 14; }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            nwdziel_Click(sender, e);
            nwwiel_Click(sender, e);
        }

        private void Green_Click(object sender, RoutedEventArgs e)
        {
            pole.Background = System.Windows.Media.Brushes.Green;
            menu.Background = System.Windows.Media.Brushes.DarkGreen;
            tbx1.Background = tbx2.Background = System.Windows.Media.Brushes.Lime;
            b1.Background = b2.Background = System.Windows.Media.Brushes.Aquamarine;

            tbk1.Foreground = tbk2.Foreground = nwd.Foreground = nww.Foreground = System.Windows.Media.Brushes.White;
        }

        private void Blue_Click(object sender, RoutedEventArgs e)
        {
            pole.Background = System.Windows.Media.Brushes.DeepSkyBlue;
            menu.Background = System.Windows.Media.Brushes.LightSkyBlue;
            tbx1.Background = tbx2.Background = System.Windows.Media.Brushes.DodgerBlue;
            b1.Background = b2.Background = System.Windows.Media.Brushes.PowderBlue;

            tbk1.Foreground = tbk2.Foreground = nwd.Foreground = nww.Foreground = System.Windows.Media.Brushes.Black;
            tbx1.Foreground = tbx2.Foreground = System.Windows.Media.Brushes.White;
        }

        private void nwdziel_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbx1.Text) && !String.IsNullOrEmpty(tbx2.Text))
            {
                int x, k = Int32.Parse(tbx1.Text), n = Int32.Parse(tbx2.Text);
                l1 = k;
                l2 = n;
                if (k != 0 && n != 0)
                {
                    int a = k, b = n;
                    while (n != 0)
                    {
                        x = n;
                        n = k % n;
                        k = x;
                    }
                    najw = k;
                    nwd.Text = "NWD: " + najw.ToString();
                }
                else
                {
                    MessageBox.Show("Liczby muszą być różne od zera!");
                    najw = najm = 0;
                    nwd.Text = "NWD: " + najw.ToString();
                    nww.Text = "NWW: " + najm.ToString();
                }
            }
            else
            {
                MessageBox.Show("Daj coś w każdym polu!");
                najw = najm = 0;
                nwd.Text = "NWD: " + najw.ToString();
                nww.Text = "NWW: " + najm.ToString();
            }
        }

        private void nwwiel_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbx1.Text) && !String.IsNullOrEmpty(tbx2.Text))
            {
                int k = Int32.Parse(tbx1.Text), n = Int32.Parse(tbx2.Text);
                l1 = k;
                l2 = n;
                if (k != 0 && n != 0)
                {
                    int a = k, b = n;
                    najm = a / najw * b;
                    nww.Text = "NWW: " + najm.ToString();
                }
                else
                {
                    MessageBox.Show("Liczby muszą być różne od zera!");
                    najw = najm = 0;
                    nwd.Text = "NWD: " + najw.ToString();
                    nww.Text = "NWW: " + najm.ToString();
                }
            }
            else
            {
                MessageBox.Show("Daj coś w każdym polu!");
                najw = najm = 0;
                nwd.Text = "NWD: " + najw.ToString();
                nww.Text = "NWW: " + najm.ToString();
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        { MessageBox.Show("Autor: Pafcio\nWersja: 20.77", "O programie", MessageBoxButton.OK, MessageBoxImage.Information); }

        private void Intruction_Click(object sender, RoutedEventArgs e)
        { MessageBox.Show("NWD (Najwyższy Wspólny Dzielnik) to najwyższa możliwa liczba, przez którą podzielna jest para liczb.\n\nNWW (Najmniejsza Wspólna Wielokrotność) to najmniejsza wspólna wielokrotność pary liczb.", "Co to jest NWD i NWW?", MessageBoxButton.OK, MessageBoxImage.Question); }

        private void TypeNumericValidation(object sender, TextCompositionEventArgs e)
        { e.Handled = new Regex("[^0-9]+").IsMatch(e.Text); }
    }
}
