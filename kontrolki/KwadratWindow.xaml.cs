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

namespace kontrolki
{
    /// <summary>
    /// Logika interakcji dla klasy KwadratWindow.xaml
    /// </summary>
    public partial class KwadratWindow : Window
    {
        public KwadratWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double bok;
            if (double.TryParse(dejBok.Text, out bok) && bok > 0)
            {
                SolidColorBrush kolor = (SolidColorBrush) new BrushConverter().ConvertFromString(kombo.Text);
                kfadrad.Fill = kolor;
                //kfadrad.Stroke = kolor;
                kfadrad.Stroke = Brushes.Black;
                kfadrad.Width = bok;
                kfadrad.Height = bok;
                kfadrad.Opacity = czekboks.IsChecked.Value ? 0.3 : 1 ;
            }
        }

        private void dejBok_TextChanged(object sender, TextChangedEventArgs e)
        {
            double bok;
            if (double.TryParse(dejBok.Text, out bok) && bok > 0)
            {
                double pl = Math.Pow(bok, 2.0);
                double obw = (4 * bok);
                pole.Text = pl.ToString();
                obwod.Text = obw.ToString();
                komunikat.Content = ":D";
            }
            else
            { komunikat.Content = "Where normalny bok?"; }
        }

        private void kasuj(object sender, RoutedEventArgs e)
        {
            dejBok.Text = "";
            pole.Text = "";
            obwod.Text = "";
            komunikat.Content = "Wpisz długość boku";
            kfadrad.Width = 0;
            kfadrad.Height = 0;
            czekboks.IsChecked = false;
            kombo.SelectedIndex = 0;
        }
    }
}
