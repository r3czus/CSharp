using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace notifyPropertyChanged.ViewModels
{
    public class BackgroundViewModel : ObservableObject
    {
        private Brush color;

        public Brush Color
        {
            get
            {
                if(color == null)
                { return Brushes.Orange; }
                return color;
            }
            set 
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }
    }
}
