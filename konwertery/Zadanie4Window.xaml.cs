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

namespace konwertery
{
    /// <summary>
    /// Logika interakcji dla klasy Zadanie4Window.xaml
    /// </summary>
    public partial class Zadanie4Window : Window
    {
        public int Grade { get; set; } = 30;
        public Zadanie4Window()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
