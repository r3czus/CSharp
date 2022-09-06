using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rozszerzonyPierwszyDataGrid
{
    internal class Produkt
    {
        public string Nazwa { get; set; }
        public int Cena { get; set; }
        public bool Dostępność { get; set; }
        public string Kategoria { get; set; }
        public Uri Zdjęcie { get; set; }

        public Produkt(string nazwa, int cena, bool dostępność, string kategoria, Uri zdjęcie)
        {
            Nazwa = nazwa;
            Cena = cena;
            Dostępność = dostępność;
            Kategoria = kategoria;
            Zdjęcie = zdjęcie;
        }

        public override string ToString()
        { return Nazwa + " " + Kategoria; }
    }
}
