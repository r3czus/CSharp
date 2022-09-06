using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notifyPropertyChanged.ViewModels
{
    public class PersonViewModel : ObservableObject
    {
        private string name;

        public string Name
        {
            get 
            { 
                if(string.IsNullOrEmpty(name))
                { return "nieznany"; }
                return name; 
            }
            set
            { 
                name = value;
                OnPropertyChanged("Name");
            }
        }

    }
}
