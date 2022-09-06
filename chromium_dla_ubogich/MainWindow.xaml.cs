using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace chromium_dla_ubogich
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.Filter = "WebPage|*.html";
            dialog.Title = "Zapis";
            dynamic doc = wbPrzegladarka.Document;
            if(doc != null)
            {
                var htmlText = doc.documentElement.InnerHTML;
                if(dialog.ShowDialog() == true && htmlText != null)
                { File.WriteAllText(dialog.FileName, htmlText); }
            }
        }
        private void Drukuj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Wyjdź_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Ramka_Checked(object sender, RoutedEventArgs e)
        {
            if(brdRamka != null)
            { brdRamka.BorderThickness = new Thickness(3); }
        }

        private void Ramka_Unchecked(object sender, RoutedEventArgs e)
        {
            if (brdRamka != null)
            { brdRamka.BorderThickness = new Thickness(0); }
        }

        private void Zwiększ_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Zmniejsz_Click(object sender, RoutedEventArgs e)
        {

        }
        private void OProgramie_Click(object sender, RoutedEventArgs e)
        { MessageBox.Show("Prosta przeglądarka w 3a"); }

        private void Wstecz_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dalej_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Wejdz_Click(object sender, RoutedEventArgs e)
        {
            wbPrzegladarka.Navigate(txtAdres.Text);
        }

        private void wbPrzegladarka_Navigating(object sender, NavigatingCancelEventArgs e)
        {

        }

        private void wbPrzegladarka_Navigated(object sender, NavigationEventArgs e)
        { //HideScriptErrors(wbPrzegladarka, true); }
    }
}
