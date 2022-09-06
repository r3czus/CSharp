using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosciUno
{
    public class Score : NotifyPropertyChanged
    {
        public string Name { get; set; }
        
        public int _points;

        public int Points
        {
            get { return _points; }
            set
            {
                _points = value;
                OnPropertyChanged();
            }
        }

        public bool _isSet;
        public bool IsSet
        {
            get { return _isSet; }
            set 
            {
                _isSet = value;
                OnPropertyChanged();
            }
        }

        public bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public Score(string name)
        {
            Name = name;
            Points = 0;
            IsSet = false;
            IsEnabled = true;
        }
    }
}
