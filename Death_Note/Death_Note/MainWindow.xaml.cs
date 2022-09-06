using Microsoft.Win32;
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

namespace Death_Note
{
    public partial class MainWindow : Window
    {
        private string sciezka = null;
        private int textSize = 15;
        private bool xChanged = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            saveCheck(sender, e);
            Close();
        }

        private void Save_As_CLick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "PlainText | *.txt";
            dialog.Title = "Zapisywanie";
            if(dialog.ShowDialog() == true)
            {
                sciezka = dialog.FileName;
                File.WriteAllText(sciezka, tekst.Text);
                xChanged = false;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(sciezka != null)
            { 
                File.WriteAllText(sciezka, tekst.Text);
                xChanged = false;
            }
            else
            { Save_As_CLick(sender, e); }
        }

        private void Changed(object sender, TextChangedEventArgs e)
        { xChanged = true; }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            saveCheck(sender, e);
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PlainText | *.txt";
            dialog.Title = "Otwieranie";
            if(dialog.ShowDialog() == true)
            {
                sciezka = dialog.FileName;
                tekst.Text = File.ReadAllText(sciezka);
            }
        }


        void saveCheck(object sender, RoutedEventArgs e)
        {
            if (xChanged)
            {
                if (MessageBox.Show("Zapisać przed zamknięciem?", "Zapis", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                { Save_Click(sender, e); }
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            saveCheck(sender, e);
            tekst.Text = "";
            sciezka = null;
            xChanged = false;
        }

        private void SizeLarger_Click(object sender, RoutedEventArgs e)
        {
            textSize += 5;
            tekst.FontSize = textSize;
        }

        private void SizeSmaller_Click(object sender, RoutedEventArgs e)
        {
            if(textSize < 6)
            { return; }
            textSize -= 5;
            tekst.FontSize = textSize;
        }

        private void CiemnyMotyw_Click(object sender, RoutedEventArgs e)
        {
            tekst.Background = System.Windows.Media.Brushes.Black;
            menu.Background = System.Windows.Media.Brushes.Black;
            toolbar.Background = System.Windows.Media.Brushes.Black;

            tekst.Foreground = System.Windows.Media.Brushes.White;
            menu.Foreground = System.Windows.Media.Brushes.White;
            toolbar.Foreground = System.Windows.Media.Brushes.White;
        }

        private void JasnyMotyw_Click(object sender, RoutedEventArgs e)
        {
            tekst.Background = System.Windows.Media.Brushes.White;
            menu.Background = System.Windows.Media.Brushes.White;
            toolbar.Background = System.Windows.Media.Brushes.White;

            tekst.Foreground = System.Windows.Media.Brushes.Black;
            menu.Foreground = System.Windows.Media.Brushes.Black;
            toolbar.Foreground = System.Windows.Media.Brushes.Black;
        }
    }
}
