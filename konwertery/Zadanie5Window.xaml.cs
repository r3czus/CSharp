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
    /// Logika interakcji dla klasy Zadanie5Window.xaml
    /// </summary>
    public partial class Zadanie5Window : Window
    {
        public bool showAdd { get; set; } = true;
        public Zadanie5Window()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
