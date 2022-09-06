using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listViewW1Oknie
{
    public class Osoba
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Klasa { get; set; }
        public Osoba(string imie, string nazwisko, string klasa)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Klasa = klasa;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Imie, Nazwisko, Klasa);
        }
    }
}
