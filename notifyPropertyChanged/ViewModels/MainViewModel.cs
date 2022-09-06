using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace notifyPropertyChanged.ViewModels
{
    public class MainViewModel
    {
        public PersonViewModel Person { get; set; }
        public BackgroundViewModel Background { get; set; }
        
        public MainViewModel()
        {
            Person = new PersonViewModel(); 
            Background = new BackgroundViewModel();
        }

        public void SetBackground(Brush brushcolor)
        {
            Background.Color = brushcolor;
        }
    }
}
