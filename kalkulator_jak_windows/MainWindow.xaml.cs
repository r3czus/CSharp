using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace kalkulator_jak_windows
{
    public partial class MainWindow : Window
    {
        string ciąg = "", małyCiąg = "", str = "", wpisana = "";
        bool czySkasować = false, czyWolno = true;
        Button aktualnyPrzycisk = null;
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            EventManager.RegisterClassHandler(typeof(Window), Keyboard.KeyUpEvent, new KeyEventHandler(keyUp), true);

            aktualnyPrzycisk = zero;
            timer.Interval = TimeSpan.FromSeconds(0.05);
            timer.Tick += timer_Tick; 
        }

        void timer_Tick(object sender, EventArgs e)
        { 
            aktualnyPrzycisk.Background = Brushes.Aqua;
            timer.Stop();
        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            if(czyWolno)
            {
                if (czySkasować == true)
                {
                    czyść_Click(sender, e);
                    czySkasować = false;
                }
                if (e.Key == Key.D0 || e.Key == Key.NumPad0)
                {
                    aktualnaLiczba.Text += "0";
                    ciąg += "0";
                    zero.Background = Brushes.Turquoise;
                    aktualnyPrzycisk = zero;
                }
                else if (e.Key == Key.D1 || e.Key == Key.NumPad1)
                {
                    aktualnaLiczba.Text += "1";
                    ciąg += "1";
                    jeden.Background = Brushes.Turquoise;
                    aktualnyPrzycisk = jeden;
                }
                else if (e.Key == Key.D2 || e.Key == Key.NumPad2)
                { 
                    aktualnaLiczba.Text += "2";
                    ciąg += "2";
                    dwa.Background = Brushes.Turquoise;
                    aktualnyPrzycisk = dwa;
                }
                else if (e.Key == Key.D3 || e.Key == Key.NumPad3)
                { 
                    aktualnaLiczba.Text += "3";
                    ciąg += "3";
                    trzy.Background = Brushes.Turquoise;
                    aktualnyPrzycisk = trzy;
                }
                else if (e.Key == Key.D4 || e.Key == Key.NumPad4)
                { 
                    aktualnaLiczba.Text += "4";
                    ciąg += "4";
                    cztery.Background = Brushes.Turquoise;
                    aktualnyPrzycisk = cztery;
                }
                else if (e.Key == Key.D5 || e.Key == Key.NumPad5)
                { 
                    aktualnaLiczba.Text += "5";
                    ciąg += "5";
                    pięć.Background = Brushes.Turquoise;
                    aktualnyPrzycisk = pięć;
                }
                else if (e.Key == Key.D6 || e.Key == Key.NumPad6)
                { 
                    aktualnaLiczba.Text += "6";
                    ciąg += "6";
                    sześć.Background = Brushes.Turquoise;
                    aktualnyPrzycisk = sześć;
                }
                else if (e.Key == Key.D7 || e.Key == Key.NumPad7)
                { 
                    aktualnaLiczba.Text += "7";
                    ciąg += "7";
                    siedem.Background = Brushes.Turquoise;
                    aktualnyPrzycisk = siedem;
                }
                else if (e.Key == Key.D8 || e.Key == Key.NumPad8)
                { 
                    aktualnaLiczba.Text += "8";
                    ciąg += "8";
                    osiem.Background = Brushes.Turquoise;
                    aktualnyPrzycisk = osiem;
                }
                else if (e.Key == Key.D9 || e.Key == Key.NumPad9)
                { 
                    aktualnaLiczba.Text += "9";
                    ciąg += "9";
                    dziewięć.Background = Brushes.Turquoise;
                    aktualnyPrzycisk = dziewięć;
                }
                else if (e.Key == Key.OemPlus)
                { 
                    obsługaZnaków("+");
                    dodawanie.Background = Brushes.Turquoise;
                    aktualnyPrzycisk = dodawanie;
                }
                else if (e.Key == Key.OemMinus)
                { 
                    obsługaZnaków("-");
                    odejmowanie.Background = Brushes.Turquoise;
                    aktualnyPrzycisk = odejmowanie;
                }
                else if (e.Key == Key.Multiply)
                { 
                    obsługaZnaków("*");
                    mnożenie.Background = Brushes.Turquoise;
                    aktualnyPrzycisk = mnożenie;
                }
                else if (e.Key == Key.Divide)
                { 
                    obsługaZnaków("/");
                    dzielenie.Background = Brushes.Turquoise;
                    aktualnyPrzycisk = dzielenie;
                }
                else if (e.Key == Key.Enter)
                { 
                    równaSię_Click(sender, e);
                    równaSię.Background = Brushes.Turquoise;
                    aktualnyPrzycisk = równaSię;
                }
                działanie.Text = ciąg;
                timer.Start();
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if(czySkasować == true)
            { 
                czyść_Click(sender, e);
                czySkasować = false;
            }
            str = sender.ToString();
            małyCiąg = str.Substring(str.Length - 1);
            if (małyCiąg.Any(char.IsDigit))
            {
                aktualnaLiczba.Text += małyCiąg;
                ciąg += małyCiąg;
            }
            else
            { obsługaZnaków(małyCiąg); }

            if(ciąg.Length > 0)
            {
                string firstCiąg = ciąg.Substring(0, 1);
                if (firstCiąg == "+" || firstCiąg == "*" || firstCiąg == "/")
                { ciąg = ciąg.Remove(0, 1); }
            }
            działanie.Text = ciąg;
        }

        private void obsługaZnaków(string znaczek)
        {
            aktualnaLiczba.Text = "";
            if (ciąg.Length > 0)
            {
                if (ciąg.Substring(ciąg.Length - 1).Any(char.IsDigit))
                { ciąg += znaczek; }
                else
                { ciąg = ciąg.Remove(ciąg.Length - 1, 1) + znaczek; }
            }
            else if (znaczek == "-")
            { ciąg += znaczek; }
        }

        private void TB_wPracy(object sender, RoutedEventArgs e)
        { czyWolno = false; }

        private void TB_poPracy(object sender, RoutedEventArgs e)
        { czyWolno = true; }

        private void zmiana(object sender, KeyEventArgs e)
        {
            if (czySkasować == true)
            {
                ciąg = "";
                działanie.Text = ciąg;
                czySkasować = false;
            }
            wpisana = aktualnaLiczba.Text;
            wpisana = wpisana.Substring(wpisana.Length - 1);
            ciąg += wpisana;
            działanie.Text = ciąg;
        }

        private void czyść_Click(object sender, RoutedEventArgs e)
        {
            ciąg = "";
            działanie.Text = ciąg;
            aktualnaLiczba.Text = "";
        }

        private void równaSię_Click(object sender, RoutedEventArgs e)
        {
            if(ciąg.Length > 0)
            {
                if (czySkasować == true)
                {
                    czyść_Click(sender, e);
                    czySkasować = false;
                }
                else 
                {
                    string finalCiąg = "";
                    if (!ciąg.Substring(ciąg.Length - 1).Any(char.IsDigit))
                    { ciąg = ciąg.Remove(ciąg.Length - 1, 1); }

                    aktualnaLiczba.Text = "";
                    finalCiąg = Eval(ciąg).ToString(new CultureInfo("en-us", false));
                    ciąg = ciąg + "=" + finalCiąg;
                    działanie.Text = ciąg;
                    czySkasować = true;
                }
            }
        }

        static Double Eval(String wyrażenie)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            return Convert.ToDouble(dt.Compute(wyrażenie, String.Empty));
        }
    }
}
