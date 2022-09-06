using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuUwU
{
    public class pole : NotifyPropertyChanged
    {
        private int _liczba;
        public int Liczba
        {
            get { return _liczba; }
            set
            {
                _liczba = value;
                OnPropertyChanged();
            }
        }

        private bool _isReadOnly;
        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            set
            {
                _isReadOnly = value;
                OnPropertyChanged();
            }
        }

        private string _kolorek;
        public string Kolorek
        {
            get { return _kolorek; }
            set
            {
                _kolorek = value;
                OnPropertyChanged();
            }
        }

        private string _kolorTekstu;
        public string KolorTekstu
        {
            get { return _kolorTekstu; }
            set
            {
                _kolorTekstu = value;
                OnPropertyChanged();
            }
        }

        public pole(int podanaL = 1, bool wyłączenie = true, string barwa = "white")
        {
            Liczba = podanaL;
            IsReadOnly = wyłączenie;
            Kolorek = barwa;
            if(wyłączenie == false)
            { KolorTekstu = "black"; }
            else
            { KolorTekstu = "blue"; }
        }
    }
}