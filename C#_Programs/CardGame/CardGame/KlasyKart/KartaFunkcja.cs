using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makao
{
    abstract class KartaFunkcja : Karta
    {
        //ATRYBUTY
        //KONSTRUKTORY
        public KartaFunkcja() : base(Kolor.Pik,Wartosc.k2) { }
        public KartaFunkcja(Kolor kol,Wartosc war) : base(kol,war) { }

        //METODY
        public abstract override void funkcja();
        public abstract override void funkcja(int ile);
        //GET'y SET'y
    }
}
