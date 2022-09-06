using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace kalkulatory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double d = 0, p = 0, q = 0, x1 = 0, x2 = 0;
        int dl = 0, cyfra = 0, zrobiona = 0, potega = 1;
        string wynik = "";

        public MainWindow()
        { InitializeComponent(); }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ",";
            if (double.TryParse(aa.Text, out double a) && double.TryParse(bb.Text, out double b) && double.TryParse(cc.Text, out double c))
            {
                a = double.Parse(aa.Text, NumberStyles.Any, ci);
                b = double.Parse(bb.Text, NumberStyles.Any, ci);
                c = double.Parse(cc.Text, NumberStyles.Any, ci);

                if (a == 0)
                { wzor.Content = "To jest funkcja liniowa"; }
                else
                {

                    d = (b * b) - (4 * a * c);

                    p = (b * -1) / (2 * a);
                    q = (d * -1) / (4 * a);


                    if (d > 0)
                    {
                        x1 = ((b * -1) - Math.Sqrt(d)) / (2 * a);
                        x2 = ((b * -1) + Math.Sqrt(d)) / (2 * a);
                        x1 = Math.Round(x1, 2);
                        x2 = Math.Round(x2, 2);
                        if (x1 == -0) { x1 = 0; }
                        if (x2 == -0) { x2 = 0; }
                        xx.Content = "x1 = " + x1 + "; x2 = " + x2;
                    }
                    else if (d == 0)
                    { xx.Content = "x0 = " + p; }
                    else
                    { xx.Content = "Brak miejsc zerowych"; }

                    a = Math.Round(a, 2);
                    b = Math.Round(b, 2);
                    c = Math.Round(c, 2);
                    wzor.Content = a + "x² + " + b + " x + " + c;

                    p = Math.Round(p, 2);
                    q = Math.Round(q, 2);
                    if (p == -0) { p = 0; }
                    if (q == -0) { q = 0; }
                    pq.Content = "W(" + p + "; " + q + ")";

                    d = Math.Round(d, 2);
                    if (d == -0) { d = 0; }
                    delta.Content = d;
                }
            }
            else
            {
                wzor.Content = "";
                delta.Content = "";
                pq.Content = "";
                xx.Content = "";
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string podana = liczba.Text;
            if(podana != "")
            {
                dl = podana.Length;
                while (dl > 0)
                {
                    cyfra = podana[dl - 1];
                    /*if (cyfra == 'A')
                    { cyfra = 10 }
                    else if (cyfra == 'B')
                    { cyfra = 11 }
                    else if (cyfra == 'C')
                    { cyfra = 12 }
                    else if (cyfra == 'D')
                    { cyfra = 13 }
                    else if (cyfra == 'E')
                    { cyfra = 14 }
                    else if (cyfra == 'F')
                    { cyfra = 15 }*/
                    wynik = wynik + cyfra * potega;
                    potega = potega * ;
                    d--;
                }
            }
        }
    }
}
