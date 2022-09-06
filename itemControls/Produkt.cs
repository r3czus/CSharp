using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itemControls
{
    public class Produkt
    {
        public string Nazwa { get; set; }
        public double Cena { get; set; }
        public bool Dostępność { get; set; }
        public Produkt(string nazwa, double cena, bool dostępność)
        {
            Nazwa = nazwa;
            Cena = cena;
            Dostępność = dostępność;
        }
        public override string ToString()
        {
            return Nazwa + " " + Cena + " " + Dostępność;
        }
    }
}
